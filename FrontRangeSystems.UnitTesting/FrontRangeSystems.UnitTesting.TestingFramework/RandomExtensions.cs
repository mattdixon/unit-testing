//--------------------------------------------------------------------------
// <copyright file="RandomExtensions.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace FrontRangeSystems.UnitTesting.TestingFramework
{
    public static class RandomExtensions
    {
        private static readonly char[] charList =
            GetCapitalLetters().Union(GetCursiveLetters().Union(GetNumbers())).ToArray();

        /// <summary>
        ///     Returns a random boolean value.
        /// </summary>
        /// <param name="rand">The random to be used.</param>
        /// <returns>A random boolean value.</returns>
        public static bool NextBool(this Random rand)
        {
            return rand.Next() > .5;
        }

        /// <summary>
        ///     Returns a random decimal value.
        /// </summary>
        /// <param name="rand">The random to be used.</param>
        /// <returns>A random decimal value.</returns>
        public static decimal NextDecimal(this Random rand, decimal max = 1)
        {
            return Convert.ToDecimal(rand.NextDouble()) * max;
        }

        /// <summary>
        ///     Returns a random datetime value within the given range.
        /// </summary>
        /// <param name="rand">The random to be used.</param>
        /// <param name="min">The minimum date.</param>
        /// <param name="max">The maximum date.</param>
        /// <returns>A random datetime value within the given range.</returns>
        /// <remarks>
        ///     The value returned will be greater than or equal to the given minimum date,
        ///     and less than or equal to the given maximum date.
        /// </remarks>
        public static DateTime NextDateTime(this Random rand, DateTime min, DateTime max)
        {
            return DateTime.FromOADate((max.ToOADate() - min.ToOADate()) * rand.NextDouble() + min.ToOADate());
        }

        /// <summary>
        ///     Returns a random datetime value.
        /// </summary>
        /// <param name="rand">The random to be used.</param>
        /// <returns>A random datetime value.</returns>
        public static DateTime NextDateTime(this Random rand)
        {
            return rand.NextDateTime(DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        ///     Returns a random string value with length in the given range.
        /// </summary>
        /// <param name="rand">The random to be used.</param>
        /// <param name="minLength">The minimum length for the string (default 1)</param>
        /// <param name="maxLength">The maximum length for the string (default 10)</param>
        /// <returns>A random string value with length in the given range.</returns>
        /// <remarks>
        ///     The returned string will be a random length between the minimum and maximum specified
        ///     length, consisting of random characters in the set of capital letters, lowercase letters,
        ///     and digits.
        /// </remarks>
        [SuppressMessage("Microsoft.Usage", "CA2233:OperationsShouldNotOverflow", MessageId = "maxLength+1")]
        public static string NextString(this Random rand, int minLength = 1, int maxLength = 10)
        {
            var length = minLength != maxLength ? rand.Next(minLength, maxLength + 1) : minLength;
            var sb = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                sb.Append(rand.NextFrom(charList));
            }

            return sb.ToString();
        }

        /// <summary>
        ///     Enumerates capital letters.
        /// </summary>
        /// <returns>The capital letters.</returns>
        public static IEnumerable<char> GetCapitalLetters()
        {
            for (var i = 'A'; i <= 'Z'; i++)
            {
                yield return i;
            }
        }

        /// <summary>
        ///     Enumerates lower case letters.
        /// </summary>
        /// <returns>The lower case letters.</returns>
        public static IEnumerable<char> GetCursiveLetters()
        {
            for (var i = 'a'; i <= 'z'; i++)
            {
                yield return i;
            }
        }

        /// <summary>
        ///     Enumerates digits.
        /// </summary>
        /// <returns>The digits</returns>
        public static IEnumerable<char> GetNumbers()
        {
            for (var i = '0'; i <= '9'; i++)
            {
                yield return i;
            }
        }

        /// <summary>
        ///     Retrieves a random element from the given collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="rand">The random to be used.</param>
        /// <param name="items">The collection.</param>
        /// <returns>A random element from the given collection.</returns>
        public static T NextFrom<T>(this Random rand, IEnumerable<T> items)
        {
            var lstItems = items.ToArray();
            var i = rand.Next(0, lstItems.Length);
            return lstItems[i];
        }

        /// <summary>
        ///     Retrieves a random value from the parameters.
        /// </summary>
        /// <typeparam name="T">The type of parameters.</typeparam>
        /// <param name="rand">The random to be used.</param>
        /// <param name="items">The parameters.</param>
        /// <returns>A random value from the given parameters.</returns>
        public static T NextFrom<T>(this Random rand, params T[] items)
        {
            return rand.NextFrom((IEnumerable<T>)items);
        }

        /// <summary>
        ///     Returns a random value of an arbitrary type.
        /// </summary>
        /// <param name="rnd">The random to be used.</param>
        /// <param name="objectType">The type of value to be generated.</param>
        /// <returns>A random value of the given type.</returns>
        /// <exception cref="NotImplementedException">
        ///     This method will throw NotImplemented if the given type is not a supported
        ///     type.
        /// </exception>
        /// <remarks>
        ///     <para>
        ///         This method supports generating random values of the following types:
        ///     </para>
        ///     <list type="bullet">
        ///         <listheader>
        ///             <description>Supported Types</description>
        ///         </listheader>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Boolean" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Byte" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Char" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.DateTime" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Decimal" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Double" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Int16" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Int32" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Int64" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.SByte" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Single" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.String" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.UInt16" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.UInt32" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.UInt64" />
        ///             </description>
        ///         </item>
        ///     </list>
        ///     <para>
        ///         If any other type is given, this method will throw a <see cref="NotImplementedException" />.
        ///     </para>
        /// </remarks>
        public static object Next(this Random rnd, Type objectType)
        {
            if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                objectType = objectType.GetGenericArguments()[0];

                if (objectType == typeof(Guid))
                {
                    return Guid.NewGuid();
                }
            }

            var tc = Type.GetTypeCode(objectType);
            switch (tc)
            {
                case TypeCode.Boolean:
                    return Convert.ChangeType(rnd.NextBool(), tc);

                case TypeCode.Byte:
                    var b = new byte[1] { 0 };
                    rnd.NextBytes(b);
                    return Convert.ChangeType(b[0], tc);

                case TypeCode.Char:
                    var s = rnd.NextString(1, 1);
                    return Convert.ChangeType(s[0], tc);

                case TypeCode.DBNull:
                    break;

                case TypeCode.DateTime:
                    return Convert.ChangeType(rnd.NextDateTime(), tc);

                case TypeCode.Decimal:
                    return Convert.ChangeType(rnd.NextDecimal(), tc);

                case TypeCode.Double:
                    return Convert.ChangeType(rnd.NextDouble(), tc);

                case TypeCode.Empty:
                    break;

                case TypeCode.Int16:
                    return Convert.ChangeType(rnd.Next(short.MaxValue), tc);

                case TypeCode.Int32:
                    return Convert.ChangeType(rnd.Next(), tc);

                case TypeCode.Int64:
                    return Convert.ChangeType(rnd.Next(), tc);

                case TypeCode.Object:
                    break;

                case TypeCode.SByte:
                    return Convert.ChangeType(rnd.Next(-128, 127), tc);
                case TypeCode.Single:
                    return Convert.ChangeType(rnd.NextDouble(), tc);

                case TypeCode.String:
                    return Convert.ChangeType(rnd.NextString(), tc);

                case TypeCode.UInt16:
                    return Convert.ChangeType(rnd.Next(ushort.MaxValue), tc);

                case TypeCode.UInt32:
                    return Convert.ChangeType(rnd.Next(), tc);

                case TypeCode.UInt64:
                    return Convert.ChangeType(rnd.Next(), tc);
            }

            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns a random value of an arbitrary type.
        /// </summary>
        /// <typeparam name="T">The type of value to be generated.</typeparam>
        /// <param name="rnd">The random to be used.</param>
        /// <returns>A random value of the given type.</returns>
        /// <exception cref="NotImplementedException">
        ///     This method will throw NotImplemented if the given type is not a supported
        ///     type.
        /// </exception>
        /// <remarks>
        ///     <para>
        ///         This method supports generating random values of the following types:
        ///     </para>
        ///     <list type="bullet">
        ///         <listheader>
        ///             <description>Supported Types</description>
        ///         </listheader>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Boolean" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Byte" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Char" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.DateTime" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Decimal" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Double" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Int16" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Int32" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Int64" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.SByte" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.Single" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.String" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.UInt16" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.UInt32" />
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see cref="System.UInt64" />
        ///             </description>
        ///         </item>
        ///     </list>
        ///     <para>
        ///         If any other type is given, this method will throw a <see cref="NotImplementedException" />.
        ///     </para>
        /// </remarks>
        public static T Next<T>(this Random rnd)
        {
            return (T)rnd.Next(typeof(T));
        }
    }
}