namespace ECommerce.Api.Products.Profiles
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile() 
        {
            CreateMap<Model.Product, Models.Product>();
        }
    }
}
