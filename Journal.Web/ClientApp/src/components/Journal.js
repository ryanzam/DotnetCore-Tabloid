import React, { useEffect, useState } from 'react';
import Loader from '../Util/Loader'
import { Bookmark, Book } from 'react-bootstrap-icons';

const Journal = () => {

    const [journals, setJournals] = useState([]);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        async function getJournals() {
            setLoading(true)
            const response = await fetch('post')
            const posts = await response.json()
            setJournals(posts)
            setLoading(false)
        }
        getJournals()
    },[])

    return <>
        {loading && <Loader />}
        {journals.map(j => { 
        return <div className="card mb-1">
            <div className="card-header">
                <Bookmark /> {j.title}
            </div>
            <div className="card-body">
                <h5 className="card-title">{j.title}</h5>
                <p className="card-text">{j.subTitle}</p>
                <a href={ `/details/${j.id}`} className="btn btn-primary">Read <Book /></a>
            </div>
            </div>
        })}
        {<Pagination />}
        </>
}

const Pagination = () => {
    return <div>
        <ul className="pagination">
            <li className="page-item disabled">
                <a className="page-link" href="#">&laquo;</a>
            </li>
            <li className="page-item active">
                <a className="page-link" href="#">1</a>
            </li>
            <li className="page-item">
                <a className="page-link" href="#">2</a>
            </li>
            <li className="page-item">
                <a className="page-link" href="#">3</a>
            </li>
            <li className="page-item">
                <a className="page-link" href="#">4</a>
            </li>
            <li className="page-item">
                <a className="page-link" href="#">5</a>
            </li>
            <li className="page-item">
                <a className="page-link" href="#">&raquo;</a>
            </li>
        </ul>
    </div>
}

export default Journal
