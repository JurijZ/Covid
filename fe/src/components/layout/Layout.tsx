import React from 'react';
import Container from 'react-bootstrap/Container';

type Props = {
    children?: React.ReactNode;
}

export class Layout extends React.Component<Props> {
    render() {
        return (
            <Container>
                {this.props.children}
            </Container>
        )
    }
}