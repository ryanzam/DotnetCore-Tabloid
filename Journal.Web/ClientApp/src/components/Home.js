import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

    constructor(props) {
        super(props)
        this.state = { posts: [], loading: true }
    }

    componentDidMount() {
        this.populateWithPosts();
    }

    render() {

        return (
            <>
                <div className="bg-dark text-secondary">
                    <div className="py-5">
                        <h1 className="display-5 text-center text-white">WebJournal [Tabloid]</h1>
                        <div className="col-lg-6 mx-auto">
                            <p className="fs-5 ">Share your thoughts and Knowledge, Learn different perspective!</p>
                            <div className="d-grid gap-2 d-sm-flex justify-content-sm-center">
                                <button type="button" className="btn btn-outline-info btn-lg px-4 me-sm-3 fw-bold">Learn More</button>
                                <button type="button" className="btn btn-outline-light btn-lg px-4">Sign up</button>
                            </div>
                        </div>
                    </div>
                </div>

                {this.state.loading
                    ? <p><em>Loading...</em></p>
                    :
                    <div className="row mt-3">
                        {this.state.posts?.map(p => { 
                            return (<div className="col-md-4 card text-white bg-secondary" key={p.id}>
                                <div className="card-header">{p.title}</div>
                                <div className="card-body">
                                    <h4 className="card-title">{p.subTitle}</h4>
                                    <p className="card-text">Post on : {p.createdOn}</p>
                                    <p><a className="btn btn-secondary" href="#" role="button">Read Details »</a></p>
                                </div>
                                <p></p>
                            </div>)
                        })}
                    </div>
                }
            </>
        );
    }

    async populateWithPosts() {
        const response = await fetch('post')
        const data = await response.json()
        this.setState({ posts: data, loading: false })
    }
}
