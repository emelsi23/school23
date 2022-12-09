using School.Entities;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace School.Services
{
    public interface IService<E>
    {
        public void Remove(Guid id);
        public void Add(E entity);
        public IEnumerable<E> GetAll();
        public E GetById(Guid id);
        public void Update(Guid id,E entity);

    }
    public class StudentService : IService<Student>
    {
        private readonly List<Student> _students = new List<Student>();
        public void Add(Student entity)
        {
            entity.Id = Guid.NewGuid();
            _students.Add(entity);

        }
        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(Guid id)
        {
            return _students.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            var result  =_students.Where(x => x.Id == id).FirstOrDefault();
            _students.Remove(result);
        }

        public void Update(Guid id, Student entity)
        {
            var student = GetById(id);
            student.StudentName = entity.StudentName;
            student.Title = entity.Title;
        }

        
    }
}
