import React, { Component } from 'react';

export class AddMovie extends Component {
    constructor(props) {
        super(props);
        this.state = { value: '' };

    }

  render() {
    return (
        <div>
            <form>
                <div className="form-group">
                <label className="control-label" placeholder="Title"> Title</label>
                <input className="form-control" type="text"/>
                </div>
                <div className="form-group">
                <label className="control-label" placeholder="Release Date">Release Date</label>
                <input className="form-control" type="date"/>
                </div>
                <div className="form-group">
                <label className="control-label" placeholder="Genre"> Genre </label>
                <input className="form-control" type="text" />
                </div>
                <div className="form-group">
                <label asp-for="Price" className="control-label" placeholder="Price"> Price</label>
                <input className="form-control" type="decimal"/>
                </div>
                <div className="form-group">
                <input type="submit" value="Create" className="btn btn-primary" />
                </div>
            </form>
        </div>

    );
  }
}
