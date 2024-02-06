﻿using Cinema.Services.FileAPI.Services.Abstract;
using Cinema.Services.FileAPI.Storages.Abstract;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Events.MovieImageEvents;

namespace Cinema.Services.FileAPI.Consumer
{
    public class MovieImageRollbackMessageConsumer(IStorageService _storageService, IMovieImageService _movieImageService) : IConsumer<MovieImageNotReceivedEvent>
    {
        public async Task Consume(ConsumeContext<MovieImageNotReceivedEvent> context)
        {
            await _storageService.DeleteAsync("images", context.Message.FileName);

            var file = await _movieImageService.Table.FirstOrDefaultAsync(x => x.FileName.Equals(context.Message.FileName));
            if (file is null)
                throw new Exception("File Not Found");

            _movieImageService.Table.Remove(file);
            await _movieImageService.SaveChangesAsync();
        }
    }
}
