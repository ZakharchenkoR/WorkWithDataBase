﻿using DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ManufacturerRepository : IRepository<Manufacturer>
    {
        ShopAdo db = new ShopAdo();

        public void Add(Manufacturer item)
        {
            db.Manufacturer.Add(item);
        }

        public void Delete(Manufacturer item)
        {
            db.Manufacturer.Remove(item);
        }

        public Manufacturer Get(int id)
        {
           return db.Manufacturer.Find(id);
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            return db.Manufacturer;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Manufacturer item)
        {
            foreach (var i in db.Manufacturer)
            {
                if (i.ManufacturerId == item.ManufacturerId)
                {
                    i.ManufacturerName = item.ManufacturerName;
                    break;
                }
            }
        }


        ~ManufacturerRepository()
        {
            db.Dispose();
        }
    }
}
