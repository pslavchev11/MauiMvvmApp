﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    public class UserData
    {
        private List<User> _users;
        private int _nextId;

        public UserData()
        {
            _users = new List<User>();
            _nextId = 0;
        }

        public void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }

        public bool ValidateUser(string name, string password)
        {
            foreach(var user in _users)
            {
                if(user.Name == name && user.DecryptPassword(user.Password) == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(x => x.Name == name && x.DecryptPassword(x.Password) == password).FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string name, string password)
        {
            var ret = from user in _users
                      where user.Name == name && user.DecryptPassword(user.Password) == password
                      select user.Id;
            return ret != null ? true : false;
        }

        public User getUser(string name, string password)
        {
            foreach (User user in _users)
            {
                if(user.Name == name && user.DecryptPassword(user.Password) == password)
                {
                    return user;
                }
            }
            return null;
        }

        public void SetActive(string name, DateTime date)
        {
            foreach(var user in _users)
            {
                if(user.Name == name)
                {
                    user.ExpiresDate = date;
                }
            }
        }

        public void AssignUserRole(string name, UserRolesEnum role)
        {
            foreach(var user in _users)
            {
                if(user.Name == name)
                {
                    user.Role = role;
                }
            }
        }
    }
}
