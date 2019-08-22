import React, { Component } from 'react';

export class Movie extends Component {
  static displayName = Movie.name;

  constructor (props) {
    super(props);
    this.state = { movies: [], loading: true };

    fetch('api/Movie/Index')
      .then(response => response.json())
      .then(data => {
        this.setState({ movies: data, loading: false });
      });
  }

  static rendermoviesTable (movies) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Title</th>
            <th>Release Date</th>
            <th>Genre</th>
            <th>Price</th>
          </tr>
        </thead>
        <tbody>
          {movies.map(movie =>
            <tr key={movie.id}>
              <td>{movie.title}</td>
              <td>{movie.releaseDate}</td>
              <td>{movie.genre}</td>
              <td>{movie.price}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Movie.rendermoviesTable(this.state.movies);

    return (
      <div>
        <h1>Movie List</h1>
        <p>Should see a list of movies.</p>
        {contents}
      </div>
    );
  }
}

