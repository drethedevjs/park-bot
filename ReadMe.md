# Air Garage ParkBot Challenge
# Introduction
A company that I was interviewing with asked me to create this as a coding challenge. The challenge can be viewed below.

## Instructions to Run

1. Go to [this site](https://dotnet.microsoft.com/en-us/download) and download the .NET SDK. I used .NET Core 3.1 but you should be able to use anything after that. [This video](https://www.youtube.com/watch?v=CDuUQNU7hWM) is a good resource to learn how if you prefer a walk-through video. To check if it worked, go inside your terminal and type `dotnet --version`. You should see the version installed if it worked.
2. Now to download my app. [Go here](https://github.com/athomas-wtv/park-bot) and clone my project.
3. Go inside the folder using your file explorer or Finder and delete the `obj` folder and the `bin` folder.
4. Navigate into the file and type `dotnet build` then `dotnet run`. The app should be running an is ready for input.

I didn't write the app to take the first two parameters that you mentioned in the instructions. It'll only take the last two. Here are some sample input values:

- `locate AZ`
- `locate NY` 
- `locate CA`
- `find_price_hourly_lte 2`
- `find_price_hourly_lte 4`
- `find_price_hourly_gt 4`
- `find_price_hourly_gt 2`

No, the app can't parse the values of `200` or `400` to a decimal so you just write them as an integer. If I took more time, I could do it but...oh well. I'm already way past time.
