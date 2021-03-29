using EntityFrameworkCoreStudy.Data;
using EntityFrameworkCoreStudy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCoreStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EfStudyDbContext())
            {

                #region + Linq의 분류

                // # Linq 분류(2가지)
                // 1. 쿼리 구문
                // from user in db.Users
                // where ...
                // select user

                // 2. 메서드 구문
                // db.Users.Where().ToList();

                #endregion

                // 1. SELECT
                // 1) DbSet<User> selectList = db.Users;
                // 2) List<User> selectList = db.Users.ToList();
                // 3) IEnumerable<User> selectList = db.Users.AsEnumerable();
                // 4) IQueryable<User> selectList = from user in db.Users select user;   //Linq to Sql

                // # IEnumerable vs IQueryable
                // Extension Query => 작성 가능
                // 1. IEnumerable => 쿼리 => 데이터 => Client PC Memory에 전송 => Slow
                // 2. IQueryable => 쿼리 -> 데이터 => Server Memory에 전송 => Fast

                var selectList = db.Users.ToList();

                foreach (var item in selectList)
                {
                    Console.WriteLine(item.UserName);
                }

                // 2. INSERT
                // db.Users.Add(T);
                // db.SaveChanges();

                /*
                db.Users.Add(new User
                {
                    UserName = "홍길님이",
                    UserId = "honghongss",
                    UserPassword = "1234"
                });

                db.SaveChanges();
                */

                //Console.WriteLine("Insert OK");

                // 3. UPDATE
                // db.Entry(T).State = EntityState.Modified;
                // db.SaveChanges();

                /*
                var note = new Note { NoteNo = 1, NoteContents = "사이트가 오픈 되었습니다.", NoteTitle = "사이트 오픈 안내", UserNo = 2};
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
                */

                // 4. Delete
                /*
                var note = new Note { NoteNo = 4};
                db.Notes.Remove(note);
                db.SaveChanges();
                */

                // 외래키로 사용되는 컬럼인 경우, 부모테이블 Update 및 Delete 불가
            }
        }
    }
}