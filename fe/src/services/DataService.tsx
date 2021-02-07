import {http} from './HttpService'

export interface DataResponse{
    data: TypedCase[],
    allItemsCount: number,
    maxId: number,
    pageSize: number
}

export interface CaseResponse{
    allItemsCount: number
}

export interface TypedCase{
    x?: number,
    y?: number,
    case_code?: string,
    confirmation_date?: Date,
    municipality_code?: string,
    municipality_name?: string,
    age_bracket?: string,
    gender?: string,
    object_id?: number
}

export const getData = async (id: number, pageSize: number): Promise<DataResponse> => {
    try {
        const result = await http<undefined, DataResponse>({
            path: '/data?id=' + id + '&pageSize=' + pageSize
        })

        if (result.ok && result.parsedBody){
            return result.parsedBody;
        } else {
            return null as any;
        }

    } catch (ex) {
        console.error(ex);
        return null as any;
    }
}
