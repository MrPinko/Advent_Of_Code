import { Utils } from "../utils/utils.ts";


const StringNumbers: Record<string, string> = {
	"zero": "0",
	"one": "1",
	"two": "2",
	"three": "3",
	"four": "4",
	"five": "5",
	"six": "6",
	"seven": "7",
	"eight": "8",
	"nine": "9",
}

const input = await Utils.ReadLinesFromFileAsync("01")

Utils.Print(
	solve_1(input),
	solve_2(input)
)

export function solve_1(input: string[]): number {

	const numbers: string[] = [];
	input.forEach(line => {
		numbers.push([...line].filter(char => Number(char)).join())
	})

	let res = 0
	numbers.forEach(number => {
		const num = number.split(",")
		res += Number(num[0] + num[num.length - 1])
	})

	return res
}

export function solve_2(input: string[]): number {

	const numbers: string[] = [];

	input.forEach(line => {

		const first = line.match(/\d|one|two|three|four|five|six|seven|eight|nine/);
		const last = line.match(/.*(\d|one|two|three|four|five|six|seven|eight|nine)/);

		if (first && last) {

			let valueFirst = Number(first[0])
			let valueLast = Number(last[1])
			for (const key in StringNumbers) {
				if (key === first[0])
					valueFirst = Number(StringNumbers[key])
				if (key === last[1])
					valueLast = Number(StringNumbers[key])
			}

			numbers.push(`${valueFirst},${valueLast}`)
		}

	})

	let res = 0
	numbers.forEach(number => {
		const num = number.split(",")
		res += Number(num[0] + num[num.length - 1])
	})

	return res
}



