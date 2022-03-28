import React, { useEffect, useState } from 'react'
import Loader from '../Util/Loader'
import { ChatQuote, SignpostFill, Tag } from 'react-bootstrap-icons'

const Details = (props) => {

    const [journal, setJournal] = useState(null)

    useEffect(() => {
        const { id } = props.match.params
        async function getJournal() {
            const response = await fetch('post/' + id)
            const post = await response.json()
            setJournal(post)
        }
        getJournal()
    }, [])

    return <>
        {journal !== null ?
            <div>
                <figure className="text-center">
                    <blockquote className="blockquote">
                        <h3 className="mb-0">{journal.title}</h3>
                    </blockquote>
                    <figcaption className="blockquote-footer mt-2">
                        {journal.subTitle}
                    </figcaption>
                </figure>
                <p className="lead">{journal.description}</p>
                <small className="text-muted"><SignpostFill /> {journal.createdOn.split("T")[0]}</small>
                <hr />
                <div className="mt-2">
                    <Tag size={30} />
                    {journal.categoriesPost.map(cp => {
                        return <span className="badge bg-primary">{cp.title}</span>
                    })}
                </div>
                <hr />
                <div>
                    {journal.comments.map(cmt => {
                        return <div className="alert alert-dismissible alert-light">
                            <strong>{cmt.title}</strong>
                        </div>
                    })}
                </div>
                <div className="form-group">
                    <label htmlFor="des" className="form-label mt-3"><ChatQuote /> Comment</label>
                    <textarea className="form-control" id="des" rows="5"></textarea>
                    <small id="emailHelp" className="form-text text-muted">What do you think about this journal?</small>
                    <div className="form-group">
                        <button type="submit" className="btn btn-primary mt-3">Submit Comment</button>
                    </div>
                </div>
            </div> :
            <Loader />
            }
        </>
}

export default Details
