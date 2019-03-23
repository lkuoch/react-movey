import React from "react";
import MoveyApi from "../../api/MoveyApi";
import Loader from "react-loader-spinner";

class Home extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      moviesOriginal: [],
      movies: [],
      searchTerm: "",
      fetchedMovies: false
    };
  }

  //# On load let's fetch data
  componentDidMount() {
    MoveyApi.get("GetMovieListFromAll")
      .then(response => {
        let data = Array.from(response.data);
        this.setState({
          ...this.state,
          moviesOriginal: data,
          movies: data
        });
      })
      .then(() => {
        this.state.movies.forEach((el, i) => {
          this.updateMovieDetail(el, i);
        });
      });
  }

  //# Fetch movie detail data
  updateMovieDetail = (el, i) => {
    let endpoint = `GetMovieDetailFromSingle/${el._Provider}/${el.id}`;

    //* Get each movies details
    MoveyApi.get(endpoint).then(response => {
      let newMovies = this.state.moviesOriginal;
      newMovies[i].movieDetail = response.data[0];

      this.setState({
        ...this.state,
        moviesOriginal: newMovies,
        fetchedMovies: true
      });
    });
  };

  //# Handle input changes
  onSearchInputChange = event => {
    //* Blank search - Reset results
    if (this.state.searchTerm === "" || !this.state.searchTerm) {
      this.setState({
        ...this.state,
        searchTerm: event.target.value,
        movies: this.state.moviesOriginal
      });
    }

    //* Filter results - By search term and then by price
    let filteredMovieList = this.filterMoviesByTitle(this.state.searchTerm);

    //* Update state
    this.setState({
      ...this.state,
      searchTerm: event.target.value,
      movies: filteredMovieList
    });
  };

  //# Filter movies by title
  filterMoviesByTitle = query => {
    let updatedList = this.state.moviesOriginal;
    updatedList = updatedList.filter(item => {
      return (
        item.title
          .toLowerCase()
          .search(
            query
              .replace(/[`~!@#$%^&*()_|+\-=?;:'",.<>{}[\]\\/]/gi, "")
              .toLowerCase()
          ) !== -1
      );
    });

    return updatedList;
  };

  //# Filter movies by price
  filterMoviesByPrice = () => {
    let view = this.state.movies;

    // If price doesnt exist, set it to undefined
    view.map(el => {
      if (
        typeof el.movieDetail === "undefined" ||
        !el.hasOwnProperty("movieDetail")
      ) {
        el.movieDetail = {
          price: undefined
        };
        return el;
      } else if (el.movieDetail && !el.movieDetail.hasOwnProperty("price")) {
        el.movieDetail.Price = undefined;
        return el;
      } else {
        return el;
      }
    });

    // Sort
    view.sort((a, b) => {
      return parseFloat(a.movieDetail.price) - parseFloat(b.movieDetail.price);
    });

    // Set view state
    this.setState({
      ...this.state,
      movies: view
    });
  };

  //# Movie detail loaded
  hasMovieDetailLoaded = el => {
    if (
      typeof el.movieDetail === "undefined" ||
      typeof el.movieDetail.id === "undefined"
    ) {
      return false;
    }

    return true;
  };

  //# Refetch movie details
  refetchUnloadedMovieDetailData = () => {
    this.state.moviesOriginal.forEach((el, i) => {
      if (!this.hasMovieDetailLoaded(el)) {
        this.updateMovieDetail(el, i);
      }
    });
  };

  //# Render movie detail
  renderMovieDetail(el) {
    if (!this.hasMovieDetailLoaded(el)) {
      return (
        <div className="content ui center aligned grid">
          {this.renderLoader()}
        </div>
      );
    }

    const movieDetail = el.movieDetail;
    return (
      <div className="content">
        <div className="description">
          <table className="ui definition table">
            <tbody>
              <tr>
                <td className="two wide column">Price</td>
                <td>${movieDetail.price}</td>
              </tr>
              <tr>
                <td>Plot</td>
                <td>{movieDetail.plot}</td>
              </tr>
              <tr>
                <td>Actors</td>
                <td>{movieDetail.actors}</td>
              </tr>
              <tr>
                <td>Rated</td>
                <td>{movieDetail.rated}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    );
  }

  //# Render movies list
  renderMovies() {
    let movies = this.state.movies.map((el, i) => (
      <div
        key={i}
        className={"card " + el._Provider}
        onClick={() => this.updateMovieDetail(el, i)}
      >
        <div className="content">
          <div className="header">{el.title}</div>
        </div>
        {this.renderMovieDetail(el)}
        <div className="extra content">
          <span className="right floated">{el.year}</span>
          <span className="tv icon">{el._Provider}</span>
        </div>
      </div>
    ));

    return <div className="home ui link cards">{movies}</div>;
  }

  //# Render search bar
  renderSearch() {
    return (
      <div className="ui segment">
        <div className="ui fluid icon input">
          <input
            id="search-bar-input"
            className="prompt"
            type="text"
            placeholder="Filter movies..."
            value={this.state.searchTerm}
            onChange={e => this.onSearchInputChange(e)}
          />
          <button
            className="ui icon button"
            onClick={() => this.refetchUnloadedMovieDetailData()}
          >
            <i className="sync icon" />
          </button>
          <button
            className="ui icon button"
            onClick={() => this.filterMoviesByPrice()}
          >
            <i className="sort numeric down icon" />
          </button>
        </div>
      </div>
    );
  }

  //# Show the spinner
  renderLoader() {
    return <Loader type="Oval" color="#00BFFF" height="50" width="50" />;
  }

  //# Final render
  render() {
    //* Loading
    if (!this.state.fetchedMovies) {
      return (
        <div className="ui center aligned grid">{this.renderLoader()}</div>
      );
    }

    return (
      <>
        {this.renderSearch()}
        {this.renderMovies()}
      </>
    );
  }
}

export default Home;
