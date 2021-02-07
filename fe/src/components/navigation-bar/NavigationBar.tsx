import React, { FC, useEffect} from 'react';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import {Link} from 'react-router-dom';

export const NavigationBar: FC = () => (

    <div>
        <Navbar bg="dark">
            <Nav.Link href="/">Data</Nav.Link>
            <Nav.Link href="/New">New</Nav.Link>
        </Navbar>
    </div>
)

    