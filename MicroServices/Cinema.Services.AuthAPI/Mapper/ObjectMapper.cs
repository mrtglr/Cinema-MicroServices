﻿using AutoMapper;
using Cinema.Services.AuthAPI.Mapper.UserProfile;

namespace Cinema.Services.AuthAPI.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.AddProfile<UserMapper>();

            });

            return config.CreateMapper();
        });

        public static IMapper Mapper { get { return lazy.Value; } }
    }
}
