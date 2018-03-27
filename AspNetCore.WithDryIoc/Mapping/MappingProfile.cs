using AspNetCore.WithDryIoc.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCore.WithDryIoc.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<SampleClassDto, SampleClass>();

            CreateMap<ComplexType, ComplexType>()
                .ConvertUsing<ComplexTypeConvertor>();
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
                throw new System.NotImplementedException();
            }
        }
    }
}