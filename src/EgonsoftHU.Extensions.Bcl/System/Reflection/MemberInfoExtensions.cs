// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Reflection;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods that are available for <see cref="MemberInfo"/> type.
    /// </summary>
    public static class MemberInfoExtensions
    {
        /// <summary>
        /// Indicates whether a member has the specified type.
        /// </summary>
        /// <typeparam name="TMemberType">The expected member type.</typeparam>
        /// <param name="member">The member to test.</param>
        /// <returns><see langword="true"/> if member type meets the expectation; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="member"/> is <see langword="null"/>.</exception>
        public static bool Is<TMemberType>(this MemberInfo member)
        {
            return member.Is(typeof(TMemberType));
        }

        /// <summary>
        /// Indicates whether a member has the specified type.
        /// </summary>
        /// <param name="member">The member to test.</param>
        /// <param name="memberType">The expected type of the member.</param>
        /// <returns><see langword="true"/> if member type meets the expectation; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="member"/> or <paramref name="memberType"/> is <see langword="null"/>.
        /// </exception>
        public static bool Is(this MemberInfo member, Type memberType)
        {
            member.ThrowIfNull();
            memberType.ThrowIfNull();

            return memberType == member.ReflectedType;
        }

        /// <summary>
        /// Indicates whether a member has the specified type and name.
        /// </summary>
        /// <typeparam name="TMemberType">The expected member type.</typeparam>
        /// <param name="member">The member to test.</param>
        /// <param name="memberName">The expected name of the member.</param>
        /// <param name="stringComparison">The string comparison mode for <paramref name="memberName"/> parameter.</param>
        /// <returns><see langword="true"/> if member type and name meet the expectations; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="member"/> or <paramref name="memberName"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="memberName"/> is <see cref="String.Empty"/> or consists only of white-space characters.
        /// </exception>
        public static bool Is<TMemberType>(this MemberInfo member, string memberName, StringComparison stringComparison = StringComparison.Ordinal)
        {
            return member.Is(typeof(TMemberType), memberName, stringComparison);
        }

        /// <summary>
        /// Indicates whether a member has the specified type and name.
        /// </summary>
        /// <param name="member">The member to test.</param>
        /// <param name="memberType">The expected type of the member.</param>
        /// <param name="memberName">The expected name of the member.</param>
        /// <param name="stringComparison">The string comparison mode for <paramref name="memberName"/> parameter.</param>
        /// <returns><see langword="true"/> if member type and name meet the expectations; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="member"/> or <paramref name="memberName"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="memberName"/> is <see cref="String.Empty"/> or consists only of white-space characters.
        /// </exception>
        public static bool Is(this MemberInfo member, Type memberType, string memberName, StringComparison stringComparison = StringComparison.Ordinal)
        {
            member.ThrowIfNull();
            memberType.ThrowIfNull();
            memberName.ThrowIfNullOrWhiteSpace();

            return
                memberType == member.ReflectedType
                &&
                String.Equals(memberName, member.Name, stringComparison);
        }
    }
}
