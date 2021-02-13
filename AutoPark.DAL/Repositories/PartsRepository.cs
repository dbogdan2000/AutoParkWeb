using System.Collections.Generic;
using System.Threading.Tasks;
using AutoPark.DAL.Entities;
using AutoPark.DAL.Interfaces;
using Dapper;

namespace AutoPark.DAL.Repositories
{
    public class PartsRepository : ConnectionRepository, IRepository<Part>
    {
        public PartsRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<IEnumerable<Part>> GetAll()
        {
            return await connection.QueryAsync<Part>("select * from parts");
        }

        public async Task<Part> Get(int id)
        {
            return await connection.QueryFirstAsync<Part>("select * from parts where id = @Id", new {id});
        }

        public async Task Create(Part part)
        {
            await connection.ExecuteAsync("insert into parts(part_name) values(@Part_Name)", part);
        }

        public async Task Update(Part part)
        {
            await connection.ExecuteAsync("update parts set part_name = @Part_Name where id = @Id", part);
        }

        public async Task Delete(int id)
        {
            await connection.ExecuteAsync("delete from parts where id = @id", new {id});
        }
    }
}