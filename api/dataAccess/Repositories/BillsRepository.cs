using dataAccess.Repositories.Abstractions;
using domain.Model.Contracts.Enumerators;
using domain.Model.Contracts.Interfaces;
using domain.Model.Entities;
using System;
using System.Collections.Generic;

namespace dataAccess.Repositories
{
    public class BillsRepository : Repository, IBillsRepository
    {
        public BillsRepository() : base(ConnectionStrings.MyBills)
        {

        }

        public void Delete(int id)
        {
            string sql = @"delete from bills where id = @id";
            base.Execute(sql, new { @id = id });
        }

        public Bill Get(int id)
        {
            string sql = @"select id as [Id],
	                        title as [Title], 
	                        observations as [Observations], 
	                        amount as [Amount], 
	                        expiration_date as [ExpirationDate], 
	                        [public] as [Public], 
	                        [status] as [Status],
                            [reference] as [Reference]
	                        from bills
                            where id = @id";

            var parameters = new { @id = id };
            return base.QuerySingle<Bill>(sql, parameters);
        }

        public IEnumerable<Bill> List()
        {
            string sql = @"select id as [Id],
	                        title as [Title], 
	                        observations as [Observations], 
	                        amount as [Amount], 
	                        expiration_date as [ExpirationDate], 
	                        [public] as [Public], 
	                        [status] as [Status],
                            [reference] as [Reference]
	                        from bills";

            return base.Query<Bill>(sql);
        }

        public int Update(Bill bill)
        {
            string sql = @"update bills
                           set title = @title,
                               observations = @observations,
                               amount = @amount,
                               expiration_date = @expiration_date,
                               [public] = @public,
                               [status] = @status,
                               reference = @reference
                            where id = @id
                           SELECT @@ROWCOUNT";

            var parameters = new
            {
                @id = bill.Id,
                @title = bill.Title,
                @observations = bill.Observations,
                @amount = bill.Amount,
                @expiration_date = bill.ExpirationDate,
                @public = bill.Public,
                @status = (int)bill.Status == 0 ? (int)BillStatus.PENDING : (int)bill.Status,
                @reference = bill.Reference
            };

            return base.QuerySingle<int>(sql, parameters);
        }

        public int Create(Bill bill)
        {
            var sql = @"insert into bills(
                            title, 
                            observations, 
                            amount, 
                            expiration_date, 
                            [public], 
                            [status],
                            reference
                        )
                        values(
                            @title,
                            @observations,
                            @amount,
                            @expiration_date,
                            @public,
                            @status,
                            @reference
                        )

                        SELECT SCOPE_IDENTITY()";
            var parameters = new
            {
                @title = bill.Title,
                @observations = bill.Observations,
                @amount = bill.Amount,
                @expiration_date = bill.ExpirationDate,
                @public = bill.Public,
                @status = (int)bill.Status == 0 ? (int)BillStatus.PENDING : (int) bill.Status,
                @reference = bill.Reference
            };
            return base.QuerySingle<int>(sql, parameters);
        }

        public void SetPaid(int id)
        {
            string sql = @"update bills set [status] = 2 where id = @id";
            base.Execute(sql, new { @id = id });
        }
    }
}
