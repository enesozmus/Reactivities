import Calendar from "react-calendar";
import { Menu, Header } from "semantic-ui-react";

export default function ActivityFilters() {
    return (
        <>
            <Menu vertical size='large' style={{ width: '100%', marginTop: 25 }}>
                <Header icon='filter' attached color='teal' content='Filtreler' />
                <Menu.Item
                    content='Bütün Etkinlikler'
                />
                <Menu.Item
                    content="Katılıyorum"
                />
                <Menu.Item
                    content="Ev Sahibiyim"
                />
            </Menu>
            <Header />
            <Calendar
            />
        </>
    )
}