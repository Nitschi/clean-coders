// Copyright by refactoring guru (https://refactoring.guru/design-patterns/builder/csharp/example)

using System;
using System.Collections.Generic;

namespace RefactoringGuru.DesignPatterns.Builder.Conceptual
{
    // The Builder interface specifies methods for creating the different parts
    // of the Product objects.
    public interface IBuilder
    {
        IBuilder AddPartA();
        
        IBuilder AddPartB();
        
        IBuilder AddPartC();

        Product Build();
    }
    
    // The Concrete Builder classes follow the Builder interface and provide
    // specific implementations of the building steps. Your program may have
    // several variations of Builders, implemented differently.
    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();
        
        // A fresh builder instance should contain a blank product object, which
        // is used in further assembly.
        public ConcreteBuilder()
        {
            this.Reset();
        }

        public IBuilder AddPartA()
        {
            throw new NotImplementedException();
        }

        public IBuilder AddPartB()
        {
            throw new NotImplementedException();
        }

        public IBuilder AddPartC()
        {
            throw new NotImplementedException();
        }

        public Product Build()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            this._product = new Product();
        }
        
        // All production steps work with the same product instance.
        
        // TODO: implement add interface methods
        
        // Concrete Builders are supposed to provide their own methods for
        // retrieving results. That's because various types of builders may
        // create entirely different products that don't follow the same
        // interface. Therefore, such methods cannot be declared in the base
        // Builder interface (at least in a statically typed programming
        // language).
        //
        // Usually, after returning the end result to the client, a builder
        // instance is expected to be ready to start producing another product.
        // That's why it's a usual practice to call the reset method at the end
        // of the `GetProduct` method body. However, this behavior is not
        // mandatory, and you can make your builders wait for an explicit reset
        // call from the client code before disposing of the previous result.

        // TODO: implement build interface method
    }
    
    // It makes sense to use the Builder pattern only when your products are
    // quite complex and require extensive configuration.
    //
    // Unlike in other creational patterns, different concrete builders can
    // produce unrelated products. In other words, results of various builders
    // may not always follow the same interface.
    public class Product
    {
        private List<object> _parts = new List<object>();
        
        public void Add(string part)
        {
            this._parts.Add(part);
        }
        
        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // removing last ",c"

            return "Product parts: " + str + "\n";
        }
    }
    
    // The Director is only responsible for executing the building steps in a
    // particular sequence. It is helpful when producing products according to a
    // specific order or configuration. Strictly speaking, the Director class is
    // optional, since the client can control builders directly.
    public class Director
    {
        private IBuilder _builder;
        
        public Director(IBuilder builder)
        {
            _builder = builder;
        }
        
        // The Director can construct several product variations using the same
        // building steps.
        public Product BuildMinimalViableProduct()
        {
            throw new NotImplementedException();
        }
        
        public Product BuildFullFeaturedProduct()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Implement
        }
    }
}
