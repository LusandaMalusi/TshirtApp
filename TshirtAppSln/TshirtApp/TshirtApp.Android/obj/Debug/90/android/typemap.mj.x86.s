	/* Data SHA1: c2e99c9cb2532868f13422406c7e1e71e3bf2007 */
	.file	"typemap.mj.inc"

	/* Mapping header */
	.section	.data.mj_typemap,"aw",@progbits
	.type	mj_typemap_header, @object
	.p2align	2
	.global	mj_typemap_header
mj_typemap_header:
	/* version */
	.long	1
	/* entry-count */
	.long	1420
	/* entry-length */
	.long	262
	/* value-offset */
	.long	145
	.size	mj_typemap_header, 16

	/* Mapping data */
	.type	mj_typemap, @object
	.global	mj_typemap
mj_typemap:
	.size	mj_typemap, 372041
	.include	"typemap.mj.inc"
