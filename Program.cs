using System;
using System.Collections.Generic;
using static System.Console;

namespace MenuMenu
{
    class Program
    {
        static int id = 1;
        static List<Video> videos = new List<Video>();

        static void Main(string[] args)
        {
            var vid1 = new Video()
            {
                Id = id++,
                VideoName = "Jurassic Park Best Movie Evah",
                Genre = "Documentary",
                VideoDat = "1993"

            };
            videos.Add(vid1);

            videos.Add(new Video()
            {
                Id = id++,
                VideoName = "Lars fed ferie",
                Genre = "Action Adventure",
                VideoDat = "1990"
            });

            string[] menuItems =
            {
                "List all videos",
                "Add video",
                "Delete video",
                "Edit video",
                "Find video via id",
                "Exit"
            };

            var selection = showMenu(menuItems);

            while(selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        ListVideos();
                        break;
                    case 2:
                        AddVideos();
                        break;
                    case 3:
                        DeleteVideo();
                        break;
                    case 4:
                        EditVideo();
                        break;
                    case 5:
                        FindVideoById();
                        break;
                    default:
                        break;
                }
                selection = showMenu(menuItems);
            }
            WriteLine("Thanking for using Blockbuster Videos!");

            ReadLine();
        }

        private static void ListVideos()
        {
            WriteLine("\nList of videos");
            foreach (var video in videos)
            {
                WriteLine($"Id: {video.Id} " +
                          $"Video Name: {video.VideoName} " + $"Genre: {video.Genre}" +
                          $"Video Date: {video.VideoDat}");
            }
            WriteLine("\n");
        }

        private static void EditVideo()
        {
            var video = FindVideoById();
            WriteLine("Video Name: ");
            video.VideoName = ReadLine();
            WriteLine("Genre: ");
            video.Genre = ReadLine();
            WriteLine("Video Date: ");
            video.VideoDat = ReadLine();
        }

        private static Video FindVideoById()
        {
            WriteLine("GIVE ME THE DAMN VIDEO NUMBER: ");
            int id;

            while (!int.TryParse(ReadLine(), out id))
            {
                WriteLine("Waiting on that bloody number...");
            }

            foreach (var video in videos)
            {
                return video;
            }

            return null;
        }

        private static void AddVideos()
        {
            WriteLine("Video Name: ");
            var videoName = ReadLine();

            WriteLine("Genre: ");
            var genreName = ReadLine();

            WriteLine("Video Date: ");
            var videoDat = ReadLine();

            videos.Add(new Video()
            {
                Id = id++,
                VideoName = videoName,
                Genre = genreName,
                VideoDat = videoDat
            });
        }

        private static void DeleteVideo()
        {

            var vidLocation = FindVideoById();
            if (vidLocation != null)
            {
                videos.Remove(vidLocation);
            }
        }

        private static int showMenu(string[] menuItems)
        {
            WriteLine("Welcome to Blockbuster Videos 1989:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //WriteLine((i + 1) + ":" + menuItems[i]);
                WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while( !int.TryParse(ReadLine(), out selection)
                || selection < 1
                || selection > 6)
            {
                WriteLine("You need to select a menu item between 1 and 5");
            }

            return selection;
        }
    }
}