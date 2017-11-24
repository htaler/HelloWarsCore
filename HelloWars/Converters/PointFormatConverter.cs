using System;
using System.Collections.Generic;
using HelloWars.Common.Models;
using Newtonsoft.Json;

namespace HelloWars.Common.Converters
{
    public class PointFormatConverter : JsonConverter
    {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is List<Point> pointList)
            {
                List<string> formattedList = new List<string>();

                foreach (Point point in pointList)
                {
                    formattedList.Add(GetFormattedPoint(point));
                }
                serializer.Serialize(writer, formattedList);
            }
            else
            {
                Point point = (Point)value;
                var formattedPoint = GetFormattedPoint(point);
                writer.WriteValue(formattedPoint);
            }
        }

        private static string GetFormattedPoint(Point point)
        {
            return $"{point.X}, {point.Y}";
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Point);
        }


    }
}