import React, {FC, useEffect, useState} from 'react';
import { Button } from 'react-bootstrap';
import { DataResponse, getData } from '../../services/DataService';
import { DataList } from './DataList';


export const DataPage: FC = (): JSX.Element => {

    const [data, setData] = useState<DataResponse>();
    const [maxId, setMaxId] = useState(1);

    useEffect(() => {
        doGetNextPage();
    }, []);

    const doGetNextPage = async () => {
        console.log('Fetching data')

        if (maxId == null){
            setMaxId(0);
        }

        getData(maxId, 10).then(response => {
            console.log(response.maxId)
            setData(response);
            setMaxId(response.maxId);
        })
    }

    const doGetPreviousPage = async () => {
        console.log('Fetching data')
        let Id = maxId - 20;
        if (Id < 1) { Id = 0; }

        getData(Id, 10).then(response => {
            console.log(response.maxId)
            setData(response);
            setMaxId(response.maxId);
        })
    }

    return(
        <div>
            <Button onClick={doGetPreviousPage}>
                Up
                </Button>
                <Button onClick={doGetNextPage}>
                Down
                </Button>

            <DataList data={data?.data || []} />
        </div>
    )
}