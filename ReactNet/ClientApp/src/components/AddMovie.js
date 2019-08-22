import React, { Component } from 'react';


const containerStyle = {
  marginTop: "10%",
  padding: "3%",
  backgroundColor: "#FDFFFC",
  border: "1px solid lightgrey"
};

export class AddMovie extends Component {
  constructor(props) {
    super(props);
    this.state = {value: ''};

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({value: event.target.value});
  }

  handleSubmit(event) {
    alert('A name was submitted: ' + this.state.value);
    event.preventDefault();
  }

  render() {
    return (
        <div>

            <form>
                <div class="form-group">
                <label class="control-label" placeholder="Title"> Title</label>
                <input class="form-control" type="text"/>
                </div>
                <div class="form-group">
                <label class="control-label" placeholder="Release Date">Release Date</label>
                <input class="form-control" type="date"/>
                </div>
                <div class="form-group">
                <label class="control-label" placeholder="Genre"> Genre </label>
                <input class="form-control" type="text" />
                </div>
                <div class="form-group">
                <label asp-for="Price" class="control-label" placeholder="Price"> Price</label>
                <input class="form-control" type="decimal"/>
                </div>
                <div class="form-group">
                <input type="submit" value="Create" class="btn btn-primary" />
                </div>
            </form>

        </div>

    );
  }
}
