using System;
using AspNetCore.WithoutDryIoc.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCore.WithoutDryIoc.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /*
            //this works
            CreateMap<SampleClassDto, SampleClass>();
            */

            /*
             // one way of getting the same error

             CreateMap<SampleClassDto, SampleClass>();
            CreateMap<ComplexType, ComplexType>()
                .ConvertUsing<ComplexTypeConvertor>();

            */

            /*
            // another way of getting same error

            CreateMap<SampleClassDto, SampleClass>()
                .ForMember(dest => dest.ComplexType, opt => opt.ResolveUsing<CompleTypeResolver>());
            */


            CreateMap<SampleClassDto, SampleClass>()
                .ForMember(dest => dest.Name, opt => opt.ResolveUsing<NormalTypeResolver>());


        }

        public class NormalTypeResolver : IValueResolver<SampleClassDto, SampleClass, string>
        {
            private readonly IHostingEnvironment _hosting;

            public NormalTypeResolver(IHostingEnvironment hosting)
            {
                _hosting = hosting;
            }
            public string Resolve(SampleClassDto source, SampleClass destination, string destMember, ResolutionContext context)
            {
                Console.WriteLine("you are in string resolver now!");
                throw new NotImplementedException();
            }
        }

        public class CompleTypeResolver : IValueResolver<SampleClassDto, SampleClass, ComplexType>
        {
            private readonly IHostingEnvironment _hosting;

            public CompleTypeResolver(IHostingEnvironment hosting)
            {
                _hosting = hosting;
            }
            public ComplexType Resolve(SampleClassDto source, SampleClass destination, ComplexType destMember, ResolutionContext context)
            {
                Console.WriteLine("you are in resolver now!");
                throw new NotImplementedException();
            }
        }

        public class ComplexTypeConvertor : ITypeConverter<ComplexType, ComplexType>
        {
            private readonly IHostingEnvironment _hosting;

            public ComplexTypeConvertor(IHostingEnvironment hosting)
            {
                _hosting = hosting;
            }
            public ComplexType Convert(ComplexType source, ComplexType destination, ResolutionContext context)
            {
                Console.WriteLine("you are in convertor now!");
                throw new System.NotImplementedException();
            }
        }
    }
}