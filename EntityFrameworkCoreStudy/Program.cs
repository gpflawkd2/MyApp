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
                // 1. SELECT
                // 1) DbSet<User> selectList = db.Users;
                // 2) List<User> selectList = db.Users.ToList();
                // 3) IEnumerable<User> selectList = db.Users.AsEnumerable();
                // 4) IQueryable<User> selectList = from user in db.Users select user;   //Linq to Sql

                // # IEnumerable vs IQueryable
                // Extension Query => 작성 가능
                // 1. IEnumerable => 쿼리 => 데이터 => Client PC Memory에 전송 => Slow
                // 2. IQueryable => 쿼리 -> 데이터 => Server Memory에 전송 => Fast

                /*
                var selectList = db.Users.ToList();

                foreach (var item in selectList)
                {
                    Console.WriteLine(item.UserName);
                }
                */

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


                #region + Linq의 분류

                // # Linq 분류(2가지)
                // 1. 쿼리 구문
                // from user in db.Users
                // where ...
                // select user

                // 2. 메서드 구문
                // db.Users.Where().ToList();

                #endregion


                // 5. Where() -> 조건절 -> 리스트가 가능
                var list = db.Users.Where(u => u.UserNo >= 3);

                foreach (var user in list)
                {
                    //$ : Sting Format
                    Console.WriteLine($"이름:{user.UserName}, 아이디:{user.UserId}({user.UserNo})");
                }


                // 6. First(), FirstOrDefault(), Single(), SingleOrDefault()
                // # 게시물 1개 수정 -> 데이터 가져옴
                // 특정 데이터 1개 가져오기

                // 1) First() : 조회된 데이터가 없을 때 오류 발생
                // 2) FirstOrDefault() : 조회된 데이터가 없을 때 결과값으로 null을 return
                // 3) Single() : 조회된 데이터가 없거나 2개 이상일 때 오류 발생
                // 4) SingleOrDefault() : 조회된 데이터가 2개 이상일 때 오류 발생

                // SingleOrDefault() vs FirstOrDefault()
                // SingleOrDefault() 권장
                // 중복되지 않는 조건을 사용하기

                var _user = db.Users.SingleOrDefault(u => u.UserNo == 2);
                // SELECT Top 1 * FROM Users WHERE UserName = "홍길님이"

                Console.WriteLine($"이름:{_user.UserName}, 아이디:{_user.UserId}({_user.UserNo})");


                // 7. OrderBy() -> 오름차순 정렬, OrderByDescending() -> 내림차순 정렬
                var userList = db.Users.OrderByDescending(u => u.UserName).ToList();

                foreach(var users in userList)
                {
                    Console.WriteLine($"이름:{users.UserName}, 아이디:{users.UserId}({users.UserNo})");
                }

                // 8. Join
                var noteList = db.Notes
                    .Include(u => u.User)
                    .ToList();

                foreach (var note in noteList)
                {
                    Console.WriteLine($"제목:{note.NoteTitle}, 내용:{note.NoteContents}({note.NoteNo},{note.User.UserName})");
                }
            }
        }
    }
}