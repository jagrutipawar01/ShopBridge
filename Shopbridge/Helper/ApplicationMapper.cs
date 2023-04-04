using AutoMapper;
using Shopbridge.Data;
using Shopbridge.Domain.Models;

namespace Shopbridge.Helper
{
  public class ApplicationMapper : Profile
  {
    public ApplicationMapper()
    {
      CreateMap<Items, ItemModel>();
      CreateMap<ItemModel, Items>();
    }
  }
}
