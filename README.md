# react-movey

---

### To run locally:

`NB: I tested this and got it to work locally on a Windows 10 machine with Visual Studio 2019 preview`

- Building server:

  - cd into api/movey

  - Configure `api/movey/movey/appsettings.json`

    > You will need to store the crendentials you provided here:

    ```json
    "moveyConfig": {
      "baseEndpoint": "http://xxxxxxxxx/api/",
      "token": "xxxxxxxxxxxx",
    }
    ```

  - Open movey.sln in Visual Studio and hit run

  - Don't close the browser window!

- Building frontend:

  - cd into client

  - ⚠️ Make sure the `baseURL` in `movey/client/src/api/MoveyApi.jsx` is referencing the same `url` opened by Visual Studio

  - `npm i && npm start`

  - If the data is still loading, you can press the `refresh` button on the search screen. It will make a network request for all unloaded movie elements

  - To reset search it can be a bit finnicky but they way I do it is clear search, hit `space` then `backspace`

  - Other:

    - If there are some CORS issues? 🚨

      If you open your network tab and there's a whole bunch of CORS issues, one work around I found to test locally in `Chrome` is:

      > Install this extension https://chrome.google.com/webstore/detail/allow-control-allow-origi/nlfbmbojpeacfghkpbjhddihlkkiljbi?hl=en-US

---

### Thoughts and Comments

- Couldn't load images returned by the api because whenever the image links are accessed they all

  > eg: http://ia.media-imdb.com/images/M/MV5BOTIyMDY2NGQtOGJjNi00OTk4LWFhMDgtYmE3M2NiYzM0YTVmXkEyXkFqcGdeQXVyNTU1NTcwOTk@._V1_SX300.jpg

  returned a `403 ERROR` so I decided not to waste any time

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

### Example screenshot

![](/client/assets/example_screenshot.png?raw=true "Screenshot")
