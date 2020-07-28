using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using CaWorkshop.Application.Common.Mappings;
using CaWorkshop.Domain.Entities;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists
{
    public class TodoListDto : IMapFrom<TodoList>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IList<TodoItemDto> Items { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(TodoList), GetType());
        }
    }
}