using System.Collections.Generic;
using System.Threading.Tasks;
using AutoPark.DAL.Entities;
using AutoPark.DAL.Interfaces;
using Dapper;

namespace AutoPark.DAL.Repositories
{
    public class OrdersRepository : ConnectionRepository, IRepository<Order>
    {
        public OrdersRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await connection.QueryAsync<Order>("select * from orders");
        }

        public async Task<Order> Get(int id)
        {
            return await connection.QueryFirstAsync<Order>("select * from orders where id = @id", new {id});
        }

        public async Task Create(Order order)
        {
            await connection.ExecuteAsync("insert into orders(vehicle_id) values(@Vehicle_Id)", order);
        }

        public async Task Update(Order order)
        {
            await connection.ExecuteAsync("update orders set vehicle_id = @Vehicle_Id where id = @Id", order);
        }

        public async Task Delete(int id)
        {
            await connection.ExecuteAsync("delete from orders where id = @Id", new {id});
        }
    }
}