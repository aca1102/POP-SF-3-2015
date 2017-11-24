﻿using POP_SF_3_2015.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF_3_2015.Utils
{
    public class GenericSerializer
    {
        public static List<T> Deserialize<T>(string fileName) where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var sr = new StreamReader($@"../../Data/ { fileName}"))
                {
                    return (List<T>)serializer.Deserialize(sr);
                };
            }
            catch (Exception)
            {
                throw new Exception($"Greska prilkom ucitavanja datoteke: {fileName} sa diska");
            }
        }

        public static void Serialize<T>(string fileName, List<T> listToSerialize) where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var sr = new StreamWriter($@"../../Data/ { fileName}"))
                {
                    serializer.Serialize(sr, listToSerialize);
                };
            }
            catch (Exception)
            {
                throw new Exception($"Greska prilkom upisivanja datoteke: {fileName} na disk");
            }
        }
    }
}


