﻿using System;
using XCommon.Extensions.Util;

namespace XCommon.Patterns.Ioc
{
    public static class Kernel
    {
        public static Map<TContract> Map<TContract>()
            where TContract : class
        {
            if (!typeof(TContract).CheckIsInterface() || !typeof(TContract).CheckIsAbstract())
                throw new Exception("O mapeamento deve iniciar por uma interface ou classe abstrata");

            return new Map<TContract>(typeof(TContract));
        }

        public static void Register(Type type)
        {
            RepositoryManager.Add(type, type, true, true, null);
        }

        public static void Register<TContract>(bool canChace)
        {
            RepositoryManager.Add(typeof(TContract), typeof(TContract), false, canChace, null);
        }

        public static void Register<TContract>(TContract instance)
        {
            RepositoryManager.Add(typeof(TContract), typeof(TContract), instance, true, true, null);
        }

        public static void Resolve(object target)
        {
            foreach (AtributoDetalhe<InjectAttribute> item in target.GetAtributos<InjectAttribute>())
            {
                item.Propriedade.SetValue(target, RepositoryManager.Resolve(item.Propriedade.PropertyType, item.Atributo.CanCache, item.Atributo.ForceResolve), null);
            }
        }

        public static TContract Resolve<TContract>(Type type)
        {
            return (TContract)RepositoryManager.Resolve(type, true, true);
        }

        public static TContract Resolve<TContract>(bool canCache = true)
        {
            return RepositoryManager.Resolve<TContract>(canCache);
        }

        public static bool CanResolve(Type type)
        {
            return RepositoryManager.Exists(type);
        }

        public static bool CanResolve<TContract>()
        {
            return RepositoryManager.Exists(typeof(TContract));
        }
    }
}