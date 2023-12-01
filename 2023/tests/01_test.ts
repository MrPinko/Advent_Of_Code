import { assertEquals } from "https://deno.land/std@0.208.0/assert/assert_equals.ts";
import { solve_1, solve_2 } from "../day/01.ts";
import { Utils } from "../utils/utils.ts";



Deno.test(async function Day_01_part_one() {

	const input = await Utils.ReadLinesFromFileAsync("01", "_test1")

	const solution1 = solve_1(input)
	assertEquals(solution1, 142)
});

Deno.test(async function Day_01_part_two() {

	const input = await Utils.ReadLinesFromFileAsync("01", "_test2")

	const solution1 = solve_2(input)
	assertEquals(solution1, 281)
});
