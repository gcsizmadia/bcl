// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods that are available for <see cref="Assembly"/> type.
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Gets the full path or UNC location of the loaded file that contains the manifest.
        /// </summary>
        /// <param name="assembly">The assembly the location of which</param>
        /// <returns>
        /// <para>
        /// The location of the loaded file that contains the manifest. If the loaded file
        /// was shadow-copied, the location is that of the file after being shadow-copied.
        /// </para>
        /// <para>
        /// If the assembly is loaded from a byte array, such as when using the <see cref="Assembly.Load(Byte[])" />
        /// method overload, the value returned is an empty string ("").
        /// </para>
        /// <para>
        /// If the assembly is null or a dynamic assembly (represented by an System.Reflection.Emit.AssemblyBuilder object),
        /// the value returned is an empty string ("").
        /// </para>
        /// </returns>
        public static string SafeGetLocation(this Assembly? assembly)
        {
            try
            {
                return IsDynamicAssembly(assembly) ? String.Empty : assembly.Location;
            }
            catch (NotSupportedException)
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Gets the location of the assembly as specified originally, for example, in an <see cref="AssemblyName" /> object.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns>
        /// The location of the assembly as specified originally.
        /// <para>
        /// If the assembly is null or a dynamic assembly (represented by an System.Reflection.Emit.AssemblyBuilder object),
        /// the value returned is an empty string ("").
        /// </para>
        /// </returns>
        /// <remarks>
        /// In case of .NET Core and .NET 5+
        /// <br/>- the <see cref="Assembly.CodeBase"/> property always throws <see cref="NotImplementedException"/>
        /// <br/>- this method always returns <see cref="String.Empty"/>.
        /// </remarks>
#if NET || NETCOREAPP
        [SuppressMessage(SonarQube.Category, SonarQube.S1133)]
        [Obsolete("This method uses Assembly.CodeBase property that is only included for .NET Framework compatibility. Use AssemblyExtensions.SafeGetLocation(Assembly) extension method instead.", error: true)]
#endif
        public static string SafeGetCodeBase(this Assembly? assembly)
        {
#if NET || NETCOREAPP
            return String.Empty;
#else
            try
            {
                return IsDynamicAssembly(assembly) ? String.Empty : assembly.CodeBase;
            }
            catch (NotSupportedException)
            {
                return String.Empty;
            }
#endif
        }

        private static bool IsDynamicAssembly([NotNullWhen(false)] Assembly? assembly)
        {
            return assembly?.IsDynamic ?? true;
        }
    }
}
