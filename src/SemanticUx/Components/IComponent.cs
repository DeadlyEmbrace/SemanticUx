﻿using System;
using System.Collections.Generic;

namespace SemanticUx.Components
{
    public interface IComponent : IComparable
    {
        string Id { get; set; }
        IComponent Parent { get; }
        IComponent this[int index] { get; }
        int Count { get; }
        void Add(IComponent component);
        void AddTo(IComponent component);
        IComponentList Components { get; }
        IDictionary<string, string> Attributes { get; }
        IList<string> Classes { get; }
        int ZOrder { get; }
    }
}
