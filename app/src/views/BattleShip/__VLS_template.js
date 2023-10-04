import Board from '@/components/Blocks/Board.vue';
import { __VLS_internalComponent, __VLS_componentsOption, __VLS_name, player1, grid1, size, player2, grid2 } from './Index.vue';

function __VLS_template() {
let __VLS_ctx!: InstanceType<__VLS_PickNotAny<typeof __VLS_internalComponent, new () => {}>> & {};
/* Components */
let __VLS_otherComponents!: NonNullable<typeof __VLS_internalComponent extends { components: infer C; } ? C : {}> & typeof __VLS_componentsOption;
let __VLS_own!: __VLS_SelfComponent<typeof __VLS_name, typeof __VLS_internalComponent & (new () => { $slots: typeof __VLS_slots; })>;
let __VLS_localComponents!: typeof __VLS_otherComponents & Omit<typeof __VLS_own, keyof typeof __VLS_otherComponents>;
let __VLS_components!: typeof __VLS_localComponents & __VLS_GlobalComponents & typeof __VLS_ctx;
/* Style Scoped */
type __VLS_StyleScopedClasses = {};
let __VLS_styleScopedClasses!: __VLS_StyleScopedClasses | keyof __VLS_StyleScopedClasses | (keyof __VLS_StyleScopedClasses)[];
/* CSS variable injection */
/* CSS variable injection end */
let __VLS_resolvedLocalAndGlobalComponents!: {} &
__VLS_WithComponent<'Legend', typeof __VLS_localComponents, "Legend", "Legend", "Legend"> &
__VLS_WithComponent<'Board', typeof __VLS_localComponents, "Board", "Board", "Board">;
({} as __VLS_IntrinsicElements).div; ({} as __VLS_IntrinsicElements).div;
__VLS_components.Legend;
// @ts-ignore
[Legend,];
__VLS_components.Board; __VLS_components.Board;
// @ts-ignore
[Board, Board,];
{
const __VLS_0 = ({} as __VLS_IntrinsicElements)["div"];
const __VLS_1 = __VLS_elementAsFunctionalComponent(__VLS_0);
({} as __VLS_IntrinsicElements).div;
({} as __VLS_IntrinsicElements).div;
const __VLS_2 = __VLS_1({ ...{}, class: ("container h-screen flex flex-col items-center justify-center mx-auto"), }, ...__VLS_functionalComponentArgsRest(__VLS_1));
({} as (props: __VLS_FunctionalComponentProps<typeof __VLS_0, typeof __VLS_2> & Record<string, unknown>) => void)({ ...{}, class: ("container h-screen flex flex-col items-center justify-center mx-auto"), });
const __VLS_3 = __VLS_pickFunctionalComponentCtx(__VLS_0, __VLS_2)!;
let __VLS_4!: __VLS_NormalizeEmits<typeof __VLS_3.emit>;
{
let __VLS_5!: 'Legend' extends keyof typeof __VLS_ctx ? typeof __VLS_ctx.Legend : (typeof __VLS_resolvedLocalAndGlobalComponents)['Legend'];
const __VLS_6 = __VLS_asFunctionalComponent(__VLS_5, new __VLS_5({ ...{}, "<div": (true), class: ("flex flex-row flex-nowrap gap-8"), }));
({} as { Legend: typeof __VLS_5; }).Legend;
const __VLS_7 = __VLS_6({ ...{}, "<div": (true), class: ("flex flex-row flex-nowrap gap-8"), }, ...__VLS_functionalComponentArgsRest(__VLS_6));
({} as (props: __VLS_FunctionalComponentProps<typeof __VLS_5, typeof __VLS_7> & Record<string, unknown>) => void)({ ...{}, "<div": (true), class: ("flex flex-row flex-nowrap gap-8"), });
const __VLS_8 = __VLS_pickFunctionalComponentCtx(__VLS_5, __VLS_7)!;
let __VLS_9!: __VLS_NormalizeEmits<typeof __VLS_8.emit>;
{
let __VLS_10!: 'Board' extends keyof typeof __VLS_ctx ? typeof __VLS_ctx.Board : (typeof __VLS_resolvedLocalAndGlobalComponents)['Board'];
const __VLS_11 = __VLS_asFunctionalComponent(__VLS_10, new __VLS_10({ ...{}, class: ("w-1/2"), player: ((__VLS_ctx.player1)), grid: ((__VLS_ctx.grid1)), size: ((__VLS_ctx.size)), }));
({} as { Board: typeof __VLS_10; }).Board;
const __VLS_12 = __VLS_11({ ...{}, class: ("w-1/2"), player: ((__VLS_ctx.player1)), grid: ((__VLS_ctx.grid1)), size: ((__VLS_ctx.size)), }, ...__VLS_functionalComponentArgsRest(__VLS_11));
({} as (props: __VLS_FunctionalComponentProps<typeof __VLS_10, typeof __VLS_12> & Record<string, unknown>) => void)({ ...{}, class: ("w-1/2"), player: ((__VLS_ctx.player1)), grid: ((__VLS_ctx.grid1)), size: ((__VLS_ctx.size)), });
const __VLS_13 = __VLS_pickFunctionalComponentCtx(__VLS_10, __VLS_12)!;
let __VLS_14!: __VLS_NormalizeEmits<typeof __VLS_13.emit>;
}
{
let __VLS_15!: 'Board' extends keyof typeof __VLS_ctx ? typeof __VLS_ctx.Board : (typeof __VLS_resolvedLocalAndGlobalComponents)['Board'];
const __VLS_16 = __VLS_asFunctionalComponent(__VLS_15, new __VLS_15({ ...{}, class: ("w-1/2"), player: ((__VLS_ctx.player2)), grid: ((__VLS_ctx.grid2)), size: ((__VLS_ctx.size)), }));
({} as { Board: typeof __VLS_15; }).Board;
const __VLS_17 = __VLS_16({ ...{}, class: ("w-1/2"), player: ((__VLS_ctx.player2)), grid: ((__VLS_ctx.grid2)), size: ((__VLS_ctx.size)), }, ...__VLS_functionalComponentArgsRest(__VLS_16));
({} as (props: __VLS_FunctionalComponentProps<typeof __VLS_15, typeof __VLS_17> & Record<string, unknown>) => void)({ ...{}, class: ("w-1/2"), player: ((__VLS_ctx.player2)), grid: ((__VLS_ctx.grid2)), size: ((__VLS_ctx.size)), });
const __VLS_18 = __VLS_pickFunctionalComponentCtx(__VLS_15, __VLS_17)!;
let __VLS_19!: __VLS_NormalizeEmits<typeof __VLS_18.emit>;
}
(__VLS_8.slots!).default;
}
(__VLS_3.slots!).default;
}
if (typeof __VLS_styleScopedClasses === 'object' && !Array.isArray(__VLS_styleScopedClasses)) {
}
var __VLS_slots!: {};
// @ts-ignore
[player1, grid1, size, player1, grid1, size, player1, grid1, size, player2, grid2, size, player2, grid2, size, player2, grid2, size,];
return __VLS_slots;
}
