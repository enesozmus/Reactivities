import { observer } from "mobx-react-lite";
import Calendar from "react-calendar";
import { Menu, Header } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";

export default observer(function ActivityFilters() {

    const { activityStore: { predicate, setPredicate } } = useStore();

    return (
        <>
            <Menu vertical size='large' style={{ width: '100%', marginTop: 25 }}>

                <Header icon='filter' attached color='teal' content='Filtreler' />

                <Menu.Item
                    content='Bütün Etkinlikler'
                    active={predicate.has('all')}
                    onClick={() => setPredicate('all', 'true')}
                />
                <Menu.Item
                    content="Katılıyorum"
                    active={predicate.has('isGoing')}
                    onClick={() => setPredicate('isGoing', 'true')}
                />
                <Menu.Item
                    content="Ev Sahibiyim"
                    active={predicate.has('isHost')}
                    onClick={() => setPredicate('isHost', 'true')}
                />
            </Menu>
            <Header />
            <Calendar
                onChange={(date: any) => setPredicate('startDate', date as Date)}
                value={predicate.get('startDate') || new Date()}
            />
        </>
    )
})