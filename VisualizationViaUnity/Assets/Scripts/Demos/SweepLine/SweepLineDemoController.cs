using System.Collections.Generic;
using Algorithms.Graphics;
using Algorithms.Structure;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Demo.SweepLine
{
    public class SweepLineDemoController : MonoBehaviour
    {
        [SerializeField] private int _linesAmount = 100;

        [SerializeField] private int _screenWidth = 1920;
        [SerializeField] private int _screenHeight = 1080;

        private List<Line> _lines = new List<Line>();
        private List<Line> _intersections;
        
        private void Start()
        {
            Generate();

            _intersections = SweepLineAlgorithm.CalculateIntersections(_lines);
        }

        private void OnDrawGizmos()
        {
            foreach (var line in _lines)
            {
                if (_intersections.Contains(line))
                {
                    Gizmos.color = Color.red;
                }
                else
                {
                    Gizmos.color = Color.white;
                }
                
                Gizmos.DrawWireSphere(new Vector3(line.A.X, line.A.Y), 5);
                Gizmos.DrawWireSphere(new Vector3(line.B.X, line.B.Y), 5);
                Gizmos.DrawLine(new Vector3(line.A.X, line.A.Y), new Vector3(line.B.X, line.B.Y));
            }
            
        }

        /**
         * Generate horizonal and vertical segments
         */
        private void Generate()
        {
            _lines.Clear();
            
            for (var i = 0; i < _linesAmount; i++)
            {
                var x1 = 0;
                var x2 = 0;

                var y1 = 0;
                var y2 = 0;
                
                if (Random.Range(0f, 1f) > 0.5f)
                {
                    x1 = Random.Range(0, _screenWidth);
                    x2 = Random.Range(0, _screenWidth);

                    if (x1 > x2)
                    {
                        var tmp = x1;
                        x1 = x2;
                        x2 = tmp;
                    }

                    y1 = y2 = Random.Range(0, _screenHeight);
                }
                else
                {
                    x1 = x2 = Random.Range(0, _screenWidth);

                    y1 = Random.Range(0, _screenHeight);
                    y2 = Random.Range(0, _screenHeight);
                    
                    if (y1 > y2)
                    {
                        var tmp = y1;
                        y1 = y2;
                        y2 = tmp;
                    }
                }

                var line = new Line(new Point(x1, y1), new Point(x2, y2));
                
                _lines.Add(line);
            }
        }
    }
}
