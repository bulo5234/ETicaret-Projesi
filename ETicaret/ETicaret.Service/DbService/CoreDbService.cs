﻿using ETicaret.Core.Entity;
using ETicaret.Core.Service;
using ETicaret.Model.Context;
using ETicaret.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Service.DbService
{
    // Generic Repository Pattern : Belirtilen bütün modeller için ortak SQL sorguları yazmak için kullanılan bir yazılım tasarım desenidir.
    public class CoreDbService<T> : IDbService<T> where T : CoreEntity
    {
        private readonly ETicaretContext _db;
        public CoreDbService(ETicaretContext db)
        {
            _db = db;
        }

        public bool Add(T item)
        {
            try
            {
                _db.Set<T>().Add(item); // Set<T>() ifadesi ile herhangi bir model T hangi tabloya denk geliyorsa o tabloya ekleme yapar.
                return Save();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(T item)
        {
            try
            {
                _db.Set<T>().Remove(item);
                return Save();
            }
            catch (Exception)
            {
                return false;
            }
        }

      
        public List<T> GetAll() => _db.Set<T>().ToList();

        public T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(T item)
        {
            try
            {
                _db.Set<T>().Update(item);
                return Save();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}