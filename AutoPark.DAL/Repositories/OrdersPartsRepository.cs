using System.Collections.Generic;
using System.Threading.Tasks;
using AutoPark.DAL.Entities;
using AutoPark.DAL.Interfaces;
using Dapper;

namespace AutoPark.DAL.Repositories
{
    public class OrdersPartsRepository: ConnectionRepository, IRepository<OrderPart>
    {
        public OrdersPartsRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<IEnumerable<OrderPart>> GetAll()
        {
            return await connection.QueryAsync<OrderPart>("select * from orders_parts");
        }

        public async Task<OrderPart> Get(int id)
        {
            return await connection.QueryFirstAsync<OrderPart>("select * from orders_parts where id = @Id", new {id});
        }

        public async Task Create(OrderPart orderPart)
        {
            await connection.ExecuteAsync(
                "insert into orders_parts(parts_number, part_id, order_id) values(@Parts_Mumber, @Part_Id, @Order_Id)",
                orderPart);
        }

        public async Task Update(OrderPart orderPart)
        {
            await connection.ExecuteAsync(
                "update orders_parts set parts_number = @Parts_Number, part_id = @Part_Id, order_id = @Order_Id where id = @Id",
                orderPart);
        }

        public async Task Delete(int id)
        {
            await connection.ExecuteAsync("delete from orders_parts where id = @Id", new {id});
        }
    }
}