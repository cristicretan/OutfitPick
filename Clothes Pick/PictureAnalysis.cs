using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes_Pick
{
    public class KCluster
    {
        private readonly List<Color> _colours;

        /// Creates a new K-Means Cluster set
        /// The initial centre point for the set</param>
        public KCluster(Color centre)
        {
            Centre = centre;
            _colours = new List<Color>();
        }

        /// The current centre point of the cluster
        public Color Centre { get; set; }

        /// The number of points this cluster had before RecalculateCentre was called
        public int PriorCount { get; set; }

        /// Add new colour  to the cluster. This means that the next time will be considered in the centre calculation
        public void Add(Color colour)
        {
            _colours.Add(colour);
        }

        /// <summary>
        /// Based on all the items that have been <seealso cref="Add">Added</seealso> to this cluster calculates the centre.
        /// </summary>
        /// <param name="threshold">If the centre has moved by at least this value cluster has not yet converged and needs to be recalculated</param>
        /// <returns><c>true</c> if the recalculated centre's euclidean distance from the old centre is at least <paramref name="threshold"/>. <c>false</c> if it is less than this value</returns>
        public bool RecalculateCentre(double threshold = 0.0d)
        {
            Color updatedCentre;

            if (_colours.Count > 0)
            {
                float r = 0;
                float g = 0;
                float b = 0;

                foreach (Color color in _colours)
                {
                    r += color.R;
                    g += color.G;
                    b += color.B;
                }

                updatedCentre = Color.FromArgb((int)Math.Round(r / _colours.Count), (int)Math.Round(g / _colours.Count), (int)Math.Round(b / _colours.Count));
            }
            else
            {
                updatedCentre = Color.FromArgb(0, 0, 0, 0);
            }

            double distance = EuclideanDistance(Centre, updatedCentre);
            Centre = updatedCentre;

            PriorCount = _colours.Count;
            _colours.Clear();

            return distance > threshold;
        }

        /// Returns the Euclidean distance of colour from the current cluster centre point
        public double DistanceFromCentre(Color colour)
        {
            return EuclideanDistance(colour, Centre);
        }

        /// Euclidean distance between two colours, c1 and c2
        public static double EuclideanDistance(Color c1, Color c2)
        {
            double distance = Math.Pow(c1.R - c2.R, 2) + Math.Pow(c1.G - c2.G, 2) + Math.Pow(c1.B - c2.B, 2);

            return Math.Sqrt(distance);
        }
    }

    public class KMeansClusteringCalculator
    {

        /// Calculates the k clusters for colours. Iterations continues until clusters move by less than threshold
        /// k The number of clusters to calculate (eg. The number of results to return)
        /// coulours The list of colours to calculate k for
        /// Threshold for iteration. A lower value should produce more correct results but requires more iterations and for some coulours may never produce a result
        /// returns The k colours for the image in descending order from most common to least common
        public IList<Color> Calculate(int k, IList<Color> colours, double threshold = 0.0d)
        {
            List<KCluster> clusters = new List<KCluster>();

            //   Create K clusters with a random data point from our input.
            //   We make sure not to use the same index twice for two inputs
            Random random = new Random();
            List<int> usedIndexes = new List<int>();
            while (clusters.Count < k)
            {
                int index = random.Next(0, colours.Count);
                if (usedIndexes.Contains(index) == true)
                {
                    continue;
                }

                usedIndexes.Add(index);
                KCluster cluster = new KCluster(colours[index]);
                clusters.Add(cluster);
            }

            bool updated = false;
            do
            {
                updated = false;
                // For each colour in our input determine which cluster's centre point is the closest and add the colour to the cluster
                foreach (Color colour in colours)
                {
                    double shortestDistance = float.MaxValue;
                    KCluster closestCluster = null;

                    foreach (KCluster cluster in clusters)
                    {
                        double distance = cluster.DistanceFromCentre(colour);
                        if (distance < shortestDistance)
                        {
                            shortestDistance = distance;
                            closestCluster = cluster;
                        }
                    }

                    closestCluster.Add(colour);
                }

                // Recalculate the clusters centre.
                foreach (KCluster cluster in clusters)
                {
                    if (cluster.RecalculateCentre(threshold) == true)
                    {
                        updated = true;
                    }
                }

                // If we updated any centre point this iteration then repeat
            } while (updated == true);

            return clusters.OrderByDescending(c => c.PriorCount).Select(c => c.Centre).ToList();
        }
    }
}
