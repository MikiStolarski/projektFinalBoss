import { useEffect, useState } from "react";
 
import "./App.css";
 
import { getTickets, createTicket } from "./utils/api";
 
export default function App()
{
    const [form, setForm] = useState({
        fullName: "",
        email: "",
        description: "",
        category: "Misc"
    });
 
    const [tickets, setTickets] = useState([]);
 
    const [message, setMessage] = useState("");
 
    useEffect(() =>
    {
        async function fetchTickets()
        {
            try
            {
                const data = await getTickets();
 
                setTickets(data);
            }
            catch
            {
                setMessage("Nie załadowano tikecików");
            }
        }
 
        fetchTickets();
 
    }, []);
 
    function handleChange(e)
    {
        setForm({
            ...form,
            [e.target.name]: e.target.value
        });
    }
 
    async function handleSubmit(e)
    {
        e.preventDefault();
 
        try
        {
            if (form.description.length < 10)
            {
                setMessage("Opis minimum 10 znaków");
                return;
            }
 
            await createTicket(form);
 
            setMessage("Tikecik dodany");
 
            setForm({
                fullName: "",
                email: "",
                description: "",
                category: "Misc"
            });
 
            const updated = await getTickets();
 
            setTickets(updated);
        }
        catch
        {
            setMessage("Error");
        }
    }
 
    return (
        <div className="min-h-screen bg-emerald-50 p-8">
 
            <form
                onSubmit={handleSubmit}
                className="space-y-4 bg-white p-6 rounded-xl shadow-lg"
            >
                <h1 className="text-4xl font-bold text-transparent bg-clip-text bg-gradient-to-r from-sky-400 to-emerald-600">
                    Mandaciki na waciki
                </h1>
 
                <input
                    type="text"
                    name="fullName"
                    placeholder="Full name"
                    value={form.fullName}
                    onChange={handleChange}
                    className="border p-2 w-full rounded-lg outline-none text-sky-500"
                />
 
                <input
                    type="email"
                    name="email"
                    placeholder="Email"
                    value={form.email}
                    onChange={handleChange}
                    className="border p-2 w-full rounded-lg outline-none text-sky-500"
                />
 
                <textarea
                    name="description"
                    placeholder="Description"
                    value={form.description}
                    onChange={handleChange}
                    className="border p-2 w-full rounded-lg outline-none text-sky-500"
                />
 
                <select
                    name="category"
                    value={form.category}
                    onChange={handleChange}
                    className="border p-2 w-full rounded-lg outline-none text-sky-500"
                >
                    <option value="Misc">Misc</option>
                    <option value="Hardware">Hardware</option>
                    <option value="Software">Software</option>
                    <option value="Network">Network</option>
                </select>
 
                <button
                    type="submit"
                    className="text-white bg-gradient-to-r from-cyan-500 to-blue-500 px-4 py-2 rounded-lg cursor-pointer"
                >
                    Submit
                </button>
 
                <p className="text-blue-500">
                    {message}
                </p>
            </form>
 
            <div className="mt-10">
                <h2 className="text-3xl font-bold mb-4">
                    Tikeciki
                </h2>
 
                <div className="space-y-4">
                    {tickets.map(ticket => (
                        <div
                            key={`${ticket.id}-${ticket.createTime}`}
                            className="bg-white p-4 rounded-xl shadow"
                        >
                            <h3 className="text-xl font-bold">
                                {ticket.fullName}
                            </h3>
 
                            <p className="text-sky-600">
                                {ticket.email}
                            </p>
 
                            <p className="mt-2">
                                {ticket.description}
                            </p>
 
                            <p className="mt-2 font-semibold">
                                {ticket.category}
                            </p>
 
                            <p className="text-sm text-gray-500 mt-2">
                                {new Date(ticket.createTime).toLocaleString()}
                            </p>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
}