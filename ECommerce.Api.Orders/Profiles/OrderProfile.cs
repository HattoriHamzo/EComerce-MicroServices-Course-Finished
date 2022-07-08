namespace ECommerce.Api.Orders.Profiles
{
    public class OrderProfile : AutoMapper.Profile
    {
        public OrderProfile()
        {
            CreateMap<DataBase.Order, Model.Order>();
            CreateMap<DataBase.OrderItem, Model.OrderItem>();
        }
    }
}
