using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace SnmpUtil
{
    /// <summary>
    /// 序列化帮助类
    /// </summary>
    public class SerialiazeHelper
    {
        /// <summary>
        /// 把对象序列化并返回相应的字节
        /// </summary>
        /// <param name="obj">需要序列化的对象</param>
        /// <returns>byte[]</returns>
        public static byte[] BinarySerialize<T>(T obj) where T : class,new()
        {
            if (obj == null)
                return null;
            using (MemoryStream _memory = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(_memory, obj);
                _memory.Position = 0;
                byte[] read = new byte[_memory.Length];
                _memory.Read(read, 0, read.Length);
                _memory.Close();
                return read;
            }
        }

        /// <summary>
        /// 把字节反序列化成相应的对象
        /// </summary>
        /// <param name="bytes">字节流</param>
        /// <returns>object</returns>
        public static T BinaryDeserialize<T>(byte[] bytes) where T : class,new()
        {
            T _newOjb = null;
            if (bytes == null)
                return _newOjb;
            using (MemoryStream _memory = new MemoryStream(bytes))
            {
                _memory.Position = 0;
                BinaryFormatter formatter = new BinaryFormatter();
                _newOjb = (T)formatter.Deserialize(_memory);
                _memory.Close();
                return _newOjb;
            }
        }

        /// <summary>
        /// Xml序列化成字符串
        /// </summary>
        /// <param name="obj">需序列化对象</param>
        /// <returns>序列化后的字符串</returns>
        public static string XmlSerialiaze(object obj)
        {
            return XmlSerialiaze(obj, Encoding.Default);
        }

        /// <summary>
        /// Xml序列化成字符串
        /// </summary>
        /// <param name="obj">需序列化对象</param>
        /// <param name="encoding">字符编码</param>
        /// <returns>序列化后的字符串</returns>
        public static string XmlSerialiaze(object obj, Encoding encoding)
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                using (XmlTextWriter xtw = new XmlTextWriter(ms, encoding) { Formatting = Formatting.Indented })
                {
                    xs.Serialize(xtw, obj);
                    ms.Seek(0, SeekOrigin.Begin);
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        string str = sr.ReadToEnd();
                        xtw.Close();
                        sr.Close();
                        ms.Close();
                        return str;
                    }
                }
            }
        }

        /// <summary>
        /// Xml序列化成字符串
        /// </summary>
        /// <param name="obj">需序列化对象</param>
        /// <returns>序列化后的字符串</returns>
        public static string XmlSerialiaze<T>(T obj, Encoding encoding) where T : class, new()
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                using (XmlTextWriter xtw = new XmlTextWriter(ms, encoding) { Formatting = Formatting.Indented })
                {
                    xs.Serialize(xtw, obj);
                    ms.Seek(0, SeekOrigin.Begin);
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        string str = sr.ReadToEnd();
                        xtw.Close();
                        sr.Close();
                        ms.Close();
                        return str;
                    }
                }
            }
        }

        /// <summary>
        /// Xml反序列化从字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(string xml) where T : class, new()
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                T obj = (T)xs.Deserialize(sr);
                sr.Close();
                return obj;
            }
        }

        /// <summary>
        /// Xml反序列化从字符串
        /// </summary>
        /// <param name="xml">xml 字符串</param>
        /// <param name="type">要生成的对象类型</param>
        /// <returns>反序列化后的对象</returns>
        public static object XmlDeserialize(string xml, Type type)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xs = new XmlSerializer(type);
                object obj = xs.Deserialize(sr);
                sr.Close();
                return obj;
            }
        }

        /// <summary>
        /// Xml反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        public static void XmlDeserialize<T>(string xml, Type type, ref T obj)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xs = new XmlSerializer(type);
                obj = (T)xs.Deserialize(sr);
                sr.Close();
            }
        }
    }
}
