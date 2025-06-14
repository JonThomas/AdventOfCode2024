import { useEffect, useState } from 'react';
import './App.css';

interface AdventOfCodeSolution {
    description: string;
    solution: number;
}

function App() {
    const [solutions, setSolutions] = useState<AdventOfCodeSolution[]>();

    useEffect(() => {
        populateSolutions();
    }, []);

    const contents = solutions === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Description</th>
                    <th>Solution</th>
                </tr>
            </thead>
            <tbody>
                {solutions.map(solution =>
                    <tr key={solution.description}>
                        <td>{solution.description}</td>
                        <td>{solution.solution}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Advent of code 2025</h1>
            <p>Solutions:</p>
            {contents}
        </div>
    );

    async function populateSolutions() {
        const response = await fetch('adventofcodesolutions');
        if (response.ok) {
            const data = await response.json();
            setSolutions(data);
        }
    }
}

export default App;