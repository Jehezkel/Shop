using System.Reflection.Metadata;
using AutoMapper;

namespace Shop.Web.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}