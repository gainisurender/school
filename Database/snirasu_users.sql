--
-- PostgreSQL database dump
--

-- Dumped from database version 13.6
-- Dumped by pg_dump version 13.6

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: classroom; Type: TABLE; Schema: public; Owner: sanirasu_admin
--

CREATE TABLE public.classroom (
    class_id bigint NOT NULL,
    class_name character varying NOT NULL,
    capacity integer NOT NULL,
    no_test integer NOT NULL
);


ALTER TABLE public.classroom OWNER TO sanirasu_admin;

--
-- Name: class_class_id_seq; Type: SEQUENCE; Schema: public; Owner: sanirasu_admin
--

CREATE SEQUENCE public.class_class_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.class_class_id_seq OWNER TO sanirasu_admin;

--
-- Name: class_class_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: sanirasu_admin
--

ALTER SEQUENCE public.class_class_id_seq OWNED BY public.classroom.class_id;


--
-- Name: student; Type: TABLE; Schema: public; Owner: sanirasu_admin
--

CREATE TABLE public.student (
    student_id bigint NOT NULL,
    first_name character varying NOT NULL,
    last_name character varying NOT NULL,
    mobile bigint NOT NULL,
    class_id integer NOT NULL,
    email character varying NOT NULL
);


ALTER TABLE public.student OWNER TO sanirasu_admin;

--
-- Name: student_subject; Type: TABLE; Schema: public; Owner: sanirasu_admin
--

CREATE TABLE public.student_subject (
    subject_id bigint,
    student_id bigint
);


ALTER TABLE public.student_subject OWNER TO sanirasu_admin;

--
-- Name: student_teacher; Type: TABLE; Schema: public; Owner: sanirasu_admin
--

CREATE TABLE public.student_teacher (
    student_id bigint NOT NULL,
    teacher_id bigint NOT NULL
);


ALTER TABLE public.student_teacher OWNER TO sanirasu_admin;

--
-- Name: students_student_id_seq; Type: SEQUENCE; Schema: public; Owner: sanirasu_admin
--

CREATE SEQUENCE public.students_student_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.students_student_id_seq OWNER TO sanirasu_admin;

--
-- Name: students_student_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: sanirasu_admin
--

ALTER SEQUENCE public.students_student_id_seq OWNED BY public.student.student_id;


--
-- Name: subject; Type: TABLE; Schema: public; Owner: sanirasu_admin
--

CREATE TABLE public.subject (
    subject_id bigint NOT NULL,
    faculty_name character varying NOT NULL,
    subject_code integer NOT NULL,
    subject_name character varying NOT NULL
);


ALTER TABLE public.subject OWNER TO sanirasu_admin;

--
-- Name: subject_subject_id_seq; Type: SEQUENCE; Schema: public; Owner: sanirasu_admin
--

CREATE SEQUENCE public.subject_subject_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.subject_subject_id_seq OWNER TO sanirasu_admin;

--
-- Name: subject_subject_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: sanirasu_admin
--

ALTER SEQUENCE public.subject_subject_id_seq OWNED BY public.subject.subject_id;


--
-- Name: teacher; Type: TABLE; Schema: public; Owner: sanirasu_admin
--

CREATE TABLE public.teacher (
    teacher_id bigint NOT NULL,
    teacher_name character varying NOT NULL,
    mobile bigint NOT NULL,
    subject_id integer NOT NULL
);


ALTER TABLE public.teacher OWNER TO sanirasu_admin;

--
-- Name: teacher_teacher_id_seq; Type: SEQUENCE; Schema: public; Owner: sanirasu_admin
--

CREATE SEQUENCE public.teacher_teacher_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.teacher_teacher_id_seq OWNER TO sanirasu_admin;

--
-- Name: teacher_teacher_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: sanirasu_admin
--

ALTER SEQUENCE public.teacher_teacher_id_seq OWNED BY public.teacher.teacher_id;


--
-- Name: classroom class_id; Type: DEFAULT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.classroom ALTER COLUMN class_id SET DEFAULT nextval('public.class_class_id_seq'::regclass);


--
-- Name: student student_id; Type: DEFAULT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.student ALTER COLUMN student_id SET DEFAULT nextval('public.students_student_id_seq'::regclass);


--
-- Name: subject subject_id; Type: DEFAULT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.subject ALTER COLUMN subject_id SET DEFAULT nextval('public.subject_subject_id_seq'::regclass);


--
-- Name: teacher teacher_id; Type: DEFAULT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.teacher ALTER COLUMN teacher_id SET DEFAULT nextval('public.teacher_teacher_id_seq'::regclass);


--
-- Data for Name: classroom; Type: TABLE DATA; Schema: public; Owner: sanirasu_admin
--

COPY public.classroom (class_id, class_name, capacity, no_test) FROM stdin;
789	UKG	30	5
\.


--
-- Data for Name: student; Type: TABLE DATA; Schema: public; Owner: sanirasu_admin
--

COPY public.student (student_id, first_name, last_name, mobile, class_id, email) FROM stdin;
3	surendar	gaini	9734928659	789	s@gmail.com
\.


--
-- Data for Name: student_subject; Type: TABLE DATA; Schema: public; Owner: sanirasu_admin
--

COPY public.student_subject (subject_id, student_id) FROM stdin;
777	3
\.


--
-- Data for Name: student_teacher; Type: TABLE DATA; Schema: public; Owner: sanirasu_admin
--

COPY public.student_teacher (student_id, teacher_id) FROM stdin;
3	8985
3	8985
\.


--
-- Data for Name: subject; Type: TABLE DATA; Schema: public; Owner: sanirasu_admin
--

COPY public.subject (subject_id, faculty_name, subject_code, subject_name) FROM stdin;
777	randeep	888	social
\.


--
-- Data for Name: teacher; Type: TABLE DATA; Schema: public; Owner: sanirasu_admin
--

COPY public.teacher (teacher_id, teacher_name, mobile, subject_id) FROM stdin;
8985	sanjay	9912141854	1234
\.


--
-- Name: class_class_id_seq; Type: SEQUENCE SET; Schema: public; Owner: sanirasu_admin
--

SELECT pg_catalog.setval('public.class_class_id_seq', 1, false);


--
-- Name: students_student_id_seq; Type: SEQUENCE SET; Schema: public; Owner: sanirasu_admin
--

SELECT pg_catalog.setval('public.students_student_id_seq', 3, true);


--
-- Name: subject_subject_id_seq; Type: SEQUENCE SET; Schema: public; Owner: sanirasu_admin
--

SELECT pg_catalog.setval('public.subject_subject_id_seq', 1, false);


--
-- Name: teacher_teacher_id_seq; Type: SEQUENCE SET; Schema: public; Owner: sanirasu_admin
--

SELECT pg_catalog.setval('public.teacher_teacher_id_seq', 1, false);


--
-- Name: classroom class_pkey; Type: CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.classroom
    ADD CONSTRAINT class_pkey PRIMARY KEY (class_id);


--
-- Name: student students_pkey; Type: CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT students_pkey PRIMARY KEY (student_id);


--
-- Name: subject subject_pkey; Type: CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.subject
    ADD CONSTRAINT subject_pkey PRIMARY KEY (subject_id);


--
-- Name: teacher teacher_pkey; Type: CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT teacher_pkey PRIMARY KEY (teacher_id);


--
-- Name: student class_id; Type: FK CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT class_id FOREIGN KEY (class_id) REFERENCES public.classroom(class_id) NOT VALID;


--
-- Name: student_subject student_id; Type: FK CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.student_subject
    ADD CONSTRAINT student_id FOREIGN KEY (student_id) REFERENCES public.student(student_id) NOT VALID;


--
-- Name: student_teacher student_id; Type: FK CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.student_teacher
    ADD CONSTRAINT student_id FOREIGN KEY (student_id) REFERENCES public.student(student_id) NOT VALID;


--
-- Name: student_subject subject_id; Type: FK CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.student_subject
    ADD CONSTRAINT subject_id FOREIGN KEY (subject_id) REFERENCES public.subject(subject_id) NOT VALID;


--
-- Name: student_teacher teacher_id; Type: FK CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.student_teacher
    ADD CONSTRAINT teacher_id FOREIGN KEY (teacher_id) REFERENCES public.teacher(teacher_id) NOT VALID;


--
-- PostgreSQL database dump complete
--

