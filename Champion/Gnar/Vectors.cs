﻿using System;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace Slutty_Gnar_Reworked
{
    public static class Vectors
    {
        public static Vector3? GetFirstWallPoint(this Vector3 from, Vector3 to, float step = 25)
        {
            var direction = (to - from).Normalized();

            for (float d = 0; d < from.Distance(to); d = d + step)
            {
                var testPoint = from + d*direction;
                if (NavMesh.GetCollisionFlags(testPoint.X, testPoint.Y).HasFlag(CollisionFlags.Wall) ||
                    NavMesh.GetCollisionFlags(testPoint.X, testPoint.Y).HasFlag(CollisionFlags.Building))
                {
                    return from + d*direction;
                }
            }

            return null;
        }

        public static Vector2? GetFirstWallPoint(this Vector2 from, Vector2 to, float step = 25)
        {
            var direction = (to - from).Normalized();

            for (float d = 0; d < from.Distance(to); d = d + step)
            {
                var testPoint = from + d*direction;
                if (NavMesh.GetCollisionFlags(testPoint.X, testPoint.Y).HasFlag(CollisionFlags.Wall) ||
                    NavMesh.GetCollisionFlags(testPoint.X, testPoint.Y).HasFlag(CollisionFlags.Building))
                {
                    return from + d*direction;
                }
            }

            return null;
        }

        public static Vector3 Rotated(this Vector3 v, float angle)
        {
            var c = Math.Cos(angle);
            var s = Math.Sin(angle);
            return new Vector3((float) (v.X*c - v.Y*s), (float) (v.Y*c + v.X*s), v.Z);
        }
    }
}