﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Smooth.IoC.Repository.UnitOfWork.Tests.TestHelpers.Registrations
{
    public static class UnityExtensions
    {
        public static IEnumerable<Type> GetInterfaces(this Assembly assembly)
        {
            return assembly.GetTypes().Where(t => t.IsInterface);
        }

        public static IList<Type> GetImplementationsOfInterface(this Assembly assembly, Type interfaceType)
        {
            var implementations = new List<Type>();

            var concreteTypes = assembly.GetTypes().Where(t =>
                !t.IsInterface &&
                !t.IsAbstract &&
                interfaceType.IsAssignableFrom(t));

            concreteTypes.ToList().ForEach(implementations.Add);

            return implementations;
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
    }
}
