# react-movey 🎬

---

### Screenshot 🏞️

![](/client/assets/example_screenshot.png?raw=true "Screenshot")

---

### Steps to run locally ✨

1: Building and running the server:

- Go into `api/movey` directory

- Modify `api/movey/movey/appsettings.json`

  > You will need to replace the `xxxx` with the crendentials that you sent:

  ```json
  "moveyConfig": {
    "baseEndpoint": "http://xxxxxxxxx/api/",
    "token": "xxxxxxxxxxxx",
  }
  ```

- Open `movey.sln` in Visual Studio and hit run

- Don't close the browser 🌏 window

<br />
2: Building the frontend:

- Go into `client` directory

- ⚠️ Make sure the `baseURL` in `movey/client/src/api/MoveyApi.jsx` is referencing the same `url` opened by Visual Studio in the browser 🌏 window

- Run the commands `npm i && npm start`

<br />

---

### Thoughts and Comments 💭

- Couldn't load images returned by the api because whenever the image links are accessed they all

  > eg: http://ia.media-imdb.com/images/M/MV5BOTIyMDY2NGQtOGJjNi00OTk4LWFhMDgtYmE3M2NiYzM0YTVmXkEyXkFqcGdeQXVyNTU1NTcwOTk@._V1_SX300.jpg

  returned a `403 ERROR` so I decided not to waste any time

- Given the timeframe I would have writen unit tests but instead shifted my focus instead of developeing a mvp and adding documentation.

- There was no need to write a server component in my opinion but in the email it was quoted:

  ```
  Key points for candidates
  The solution can be completed in C#  or Go Lang.
  ```

  so I assume I had to write one but feel free to correct me.

- People don't **normally** bootstrap a new app very often especially if it also involves a whole server as I invested probably the majority of the time just to get everything started and connected.

- Designing the application within the limited time limit meant a lot of trade offs and design decisions had to be made.

  > During the early stages of the app, I had planned a list of features that would be awesome but had to shelve some due to time contraints.

  > Bootstrapping everything took quite a large chunk of time so I decided to just implement the minumum

  > I also mostly put everything in one component but just given the time limit it seemed most appropriate

---

### Other points of interest ❗

- The movie data is automatically refreshed every 3 seconds but you can manually refresh it by pressing the 🔄 button

- Sometimes resetting the search can be a bit finnicky but a way I found useful was clearing search, hiting `space` and then `backspace`

- There were some CORS issues earlier on which should be hopefully fixed but...

  - If you open your network tab and there's still a whole bunch of CORS issues 🚨, one work around I found to test locally in `Chrome` is:

  > Install this extension https://chrome.google.com/webstore/detail/allow-control-allow-origi/nlfbmbojpeacfghkpbjhddihlkkiljbi?hl=en-US
